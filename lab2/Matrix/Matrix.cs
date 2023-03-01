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

    public bool IsSquared()
    {
        return rowsAmount == columnsAmount;
    }

    public double this[int columnNumber, int rowNumber]
    {

        get
        {
            int index = rowNumber * columnsAmount + columnNumber;
            return data[index];
        }

        set
        {
            int index = rowNumber * columnsAmount + columnNumber;
            data[index] = value;
        }
    }
}
