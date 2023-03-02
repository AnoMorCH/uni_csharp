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

    public double this[int columnIndex, int rowIndex]
    {

        get
        {
            int index = rowIndex * columnsAmount + columnIndex;
            return data[index];
        }

        set
        {
            int index = rowIndex * columnsAmount + columnIndex;
            data[index] = value;
        }
    }

    public bool IsSquared()
    {
        return rowsAmount == columnsAmount;
    }

    public bool IsEmpty()
    {
        for (int rowIndex = 0; rowIndex < rowsAmount; rowIndex++)
        {
            for (int columnIndex = 0; columnIndex < columnsAmount; columnIndex++)
            {
                int index = rowIndex * columnsAmount + columnIndex;

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

        for (int columnIndex = 1; columnIndex < columnsAmount - 1; columnIndex++)
        {
            for (int rowIndex = 0; rowIndex < columnIndex - 1; rowIndex++)
            {
                int index = rowIndex * columnsAmount + columnIndex;
                int transposedIndex = columnIndex * columnsAmount + rowIndex;

                if (data[index] != data[transposedIndex]) 
                {
                    return false;
                }
            }
        }

        return true;
    }
}
