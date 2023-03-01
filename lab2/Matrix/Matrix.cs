namespace Matrix;
public class Matrix
{
    public int rowsAmount;
    public int columnsAmount;
    double[] data;

    public Matrix(int columnsAmount, int rowsAmount)
    {
        int dataLength = rowsAmount * columnsAmount;

        this.rowsAmount = rowsAmount;
        this.columnsAmount = columnsAmount;
        data = new double[dataLength];
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
