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
}
