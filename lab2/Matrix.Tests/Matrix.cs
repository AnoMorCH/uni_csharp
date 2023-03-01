namespace Matrix.UnitTests
{
    [TestClass]
    public class MatrixUnitTests
    {
        [TestMethod]
        public void doesCreatedMatrixHaveCorrectDimensions()
        {
            Matrix matrix = new Matrix(2, 4);
            Assert.AreEqual(2, matrix.columnsAmount);
            Assert.AreEqual(4, matrix.rowsAmount);
        }

        [TestMethod]
        public void isMatrixInitialized()
        {
            int columnsAmount = 2;
            int rowsAmount = 4;
            
            Matrix matrix = new Matrix(columnsAmount, rowsAmount);
            
            for (int rowIndex = 0; rowIndex < rowsAmount; rowIndex++) 
            {
                for (int columnIndex = 0; columnIndex < columnsAmount; columnIndex++)
                {
                    Assert.AreEqual(matrix[columnIndex, rowIndex], 0);
                }
            }
        }

        [TestMethod]
        public void isValueInsertedToMatrix()
        {
            Matrix matrix = new Matrix(2, 4);
            matrix[1, 2] = 5;
            Assert.AreEqual(matrix[1, 2], 5);
        }
    }
}