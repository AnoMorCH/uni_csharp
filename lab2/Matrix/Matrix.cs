// Fullname: Anton Morozov.
// Task Option - 2. 

// TODO. Check if a matrix with columnsAmount or rowsAmount equals zero.

namespace Matrix;

public class Matrix
{
    public readonly int rowsAmount;
    public readonly int columnsAmount;
    public readonly int? size;
    private double[] data;


    public Matrix(int columnsAmount, int rowsAmount)
    {
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
        // TODO. Delete it if not needed.
        bool isEmptyCellPlace(int index, int edge)
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
            if (!isEmptyCellPlace(i, rowsAmount) && data[i] != 1)
            {
                return false;
            }

            if (isEmptyCellPlace(i, rowsAmount) && data[i] != 0)
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
        // return new Matrix(arr.GetLength(1), arr.GetLength(0));
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
}
