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

        [TestMethod]
        public void isMatrixNotSquared()
        {
            Matrix matrix = new Matrix(2, 4);
            Assert.AreEqual(matrix.size, null);
        }

        [TestMethod]
        public void isMatrixSquared()
        {
            Matrix matrix = new Matrix(3, 3);
            Assert.AreEqual(matrix.size, 3);
        } 

        [TestMethod]
        public void doesMatrixSquaredMethodWorkCorrectly()
        {
            Matrix squaredMatrix = new Matrix(3, 3);
            Assert.AreEqual(squaredMatrix.IsSquared(), true);

            Matrix nonSquaredMatrix = new Matrix(2, 4);
            Assert.AreEqual(nonSquaredMatrix.IsSquared(), false);
        }

        [TestMethod]
        public void areMatrixDimensionsReadOnly()
        {
            FieldInfo rowsAmountInfo = typeof(Matrix).GetField("rowsAmount");
            Assert.AreEqual(rowsAmountInfo.IsInitOnly, true);

            FieldInfo columnsAmountInfo = typeof(Matrix).GetField("columnsAmount");
            Assert.AreEqual(columnsAmountInfo.IsInitOnly, true);

            FieldInfo sizeInfo = typeof(Matrix).GetField("size");
            Assert.AreEqual(sizeInfo.IsInitOnly, true);
        }
    }
}