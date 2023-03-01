namespace Matrix.UnitTests
{
    [TestClass]
    public class MatrixUnitTests
    {
        [TestMethod]
        public void CreateCertainMatrix()
        {
            Matrix matrix = new Matrix(2, 4);
            Assert.AreEqual(2, matrix.columnsAmount);
            Assert.AreEqual(4, matrix.rowsAmount);
        }
    }
}