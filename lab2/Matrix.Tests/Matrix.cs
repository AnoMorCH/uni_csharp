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
        public void isValueInsertedRightToMatrix()
        {
            Matrix matrix = new Matrix(2, 4);
            matrix[1, 2] = 5;
            Assert.AreEqual(matrix[1, 2], 5);
        }
    }
}