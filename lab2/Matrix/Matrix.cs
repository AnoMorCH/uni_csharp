// Fullname: Anton Morozov.
// Task Option - 2. 

namespace Matrix;

public class Matrix
{
    public readonly int rowsAmount;
    public readonly int columnsAmount;
    public readonly int? size;
    private double[] data;


    public Matrix(int columnsAmount, int rowsAmount)
    {
        bool AreDimensionsCorrect() 
        {
            return columnsAmount > 0 && rowsAmount > 0;
        }

        if (!AreDimensionsCorrect())
        {
            throw new RankException("Rows and columns should be bigger than zero!");
        }

        int dataLength = rowsAmount * columnsAmount;

        this.rowsAmount = rowsAmount;
        this.columnsAmount = columnsAmount;
        data = new double[dataLength];

        if (IsSquared())
        {
            size = rowsAmount;
        }
        else
        {
            size = null;
        }
    }

    public double this[int columnId, int rowId]
    {

        get
        {
            int index = rowId * columnsAmount + columnId;
            return data[index];
        }

        set
        {
            int index = rowId * columnsAmount + columnId;
            data[index] = value;
        }
    }

    public bool IsSquared()
    {
        return rowsAmount == columnsAmount;
    }

    public bool IsEmpty()
    {
        for (int rowId = 0; rowId < rowsAmount; rowId++)
        {
            for (int columnId = 0; columnId < columnsAmount; columnId++)
            {
                int index = rowId * columnsAmount + columnId;

                if (data[index] != 0)
                {
                    return false;
                }
            }
        }
        return true;
    }

    // Empty Cell Place is an index of a cell in data array where a value should be equal zero.
    public bool IsUnity()
    {
        bool IsEmptyCellPlace(int index, int edge)
        {
            int step = edge + 1;
            return index % step != 0;
        }

        if (!IsSquared())
        {
            return false;
        }

        for (int i = 0; i < data.Length; i++)
        {
            if (!IsEmptyCellPlace(i, rowsAmount) && data[i] != 1)
            {
                return false;
            }

            if (IsEmptyCellPlace(i, rowsAmount) && data[i] != 0)
            {
                return false;
            }
        }

        return true;
    }

    public bool IsSymmetric()
    {
        if (!IsSquared())
        {
            return false;
        }

        for (int columnId = 1; columnId < columnsAmount; columnId++)
        {
            for (int rowId = 0; rowId < columnId; rowId++)
            {
                int index = rowId * columnsAmount + columnId;
                int transposedIndex = columnId * columnsAmount + rowId;

                if (data[index] != data[transposedIndex])
                {
                    return false;
                }
            }
        }

        return true;
    }

    public static Matrix operator *(Matrix matrix, double multiplicationValue)
    {
        for (int columnId = 0; columnId < matrix.columnsAmount; columnId++)
        {
            for (int rowId = 0; rowId < matrix.rowsAmount; rowId++)
            {
                matrix[columnId, rowId] *= multiplicationValue;
            }
        }

        return matrix;
    }

    public static Matrix operator *(Matrix matrixA, Matrix matrixB)
    {
        if (matrixA.columnsAmount != matrixB.rowsAmount)
        {
            throw new RankException();
        }

        Matrix result = new Matrix(matrixB.columnsAmount, matrixA.rowsAmount);
        double cellSum = 0;

        for (int i = 0; i < matrixA.rowsAmount; i++)
        {
            for (int j = 0; j < matrixB.columnsAmount; j++)
            {
                cellSum = 0;

                for (int k = 0; k < matrixA.columnsAmount; k++)
                {
                    cellSum += matrixA[k, i] * matrixB[j, k];
                }

                result[j, i] = cellSum;
            }
        }

        return result;
    }

    public static explicit operator Matrix(double[,] arr)
    {
        int rowsAmount = arr.GetLength(1);
        int columnsAmount = arr.GetLength(0);

        Matrix result = new Matrix(columnsAmount, rowsAmount);

        for (int columnId = 0; columnId < columnsAmount; columnId++)
        {
            for (int rowId = 0; rowId < rowsAmount; rowId++)
            {
                result[columnId, rowId] = arr[columnId, rowId];
            }
        }

        return result;
    }

    public double Trace()
    {
        if (!IsSquared())
        {
            throw new RankException();
        }

        int edge = columnsAmount;
        double trace = 0;

        for (int i = 0; i < edge; i++)
        {
            int step = i * (edge + 1);
            trace += data[step];
        }

        return trace;
    }

    public override string ToString()
    {
        string result = "";

        for (int rowId = 0; rowId < rowsAmount; rowId++)
        {
            for (int columnId = 0; columnId < columnsAmount; columnId++)
            {
                int index = rowId * columnsAmount + columnId;
                result += $"{data[index]} ";
            }

            result += "\n ";
        }

        return result;
    }

    public static Matrix GetUnity(int size)
    {
        Matrix matrix = new Matrix(size, size);

        for (int diagonalCellId = 0; diagonalCellId < size; diagonalCellId++)
        {
            matrix[diagonalCellId, diagonalCellId] = 1;
        }

        return matrix;
    }

    public static Matrix GetEmpty(int size)
    {
        return new Matrix(size, size);
    }

    // ! Cipher
    //  ',' - separator
    //  ' ' - divider
    // Input: 1 2 3, 4 5 6
    // Output:
    // [
    //     [1, 2, 3],
    //     [4, 5, 6],
    // ]
    public static bool TryParse(string cipher, out Matrix matrix)
    {
        int GetColumnsAmount(char separator, char divider)
        {
            string firstRow = cipher.Split(separator)[0];
            int columnsAmount = firstRow.Split(divider).Length;
            return columnsAmount;
        }

        int GetRowsAmount(char separator)
        {
            return cipher.Split(separator).Length;
        }

        char separator = ',';
        char divider = ' ';
        int columnsAmount = GetColumnsAmount(separator, divider);
        int rowsAmount = GetRowsAmount(separator);

        string parsedCipher = cipher.Replace(separator.ToString(), "");
        double[] numbers = Array.ConvertAll(parsedCipher.Split(divider), double.Parse);

        if (numbers.Length != columnsAmount * rowsAmount) {
            matrix = null;
            return false;
        }

        matrix = new Matrix(columnsAmount, rowsAmount);
        int numberId = 0;
        for (int rowId = 0; rowId < rowsAmount; rowId++)
        {
            for (int columnId = 0; columnId < columnsAmount; columnId++)
            {
                matrix[columnId, rowId] = numbers[numberId];
                numberId++;
            }
        }

        return true;
    }
}
