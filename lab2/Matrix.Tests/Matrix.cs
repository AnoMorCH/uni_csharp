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
        public void doesIsSquaredMethodWorkCorrectly()
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

        [TestMethod]
        public void doesIsEmptyMethodWorkCorrectly()
        {
            Matrix emptyMatrix = new Matrix(2, 4);
            Assert.AreEqual(emptyMatrix.IsEmpty(), true);

            Matrix notEmptyMatrix = new Matrix(2, 4);
            notEmptyMatrix[1, 1] = 1;
            Assert.AreEqual(notEmptyMatrix.IsEmpty(), false);
        }

        [TestMethod]
        public void doesIsUnityMethodWorkCorrectly1()
        {
            int diagonalLength = 3;
            Matrix unitySquareMatrix = new Matrix(diagonalLength, diagonalLength);

            for (int i = 0; i < diagonalLength; i++)
            {
                unitySquareMatrix[i, i] = 1;
            } 

            Assert.AreEqual(unitySquareMatrix.IsUnity(), true);
        }

        [TestMethod]
        public void doesIsUnityMethodWorkCorrectly2()
        {
            int diagonalLength = 3;
            Matrix nonUnitySquareMatrix = new Matrix(diagonalLength, diagonalLength);

            for (int i = 0; i < diagonalLength; i++)
            {
                nonUnitySquareMatrix[i, i] = i;
            } 

            nonUnitySquareMatrix[0, 0] = 1234;

            Assert.AreEqual(nonUnitySquareMatrix.IsUnity(), false);
        }

        [TestMethod]
        public void doesIsUnityMethodWorkCorrectly3()
        {
            int diagonalLength = 3;
            Matrix nonUnitySquareMatrix = new Matrix(diagonalLength, diagonalLength);

            for (int i = 0; i < diagonalLength; i++)
            {
                nonUnitySquareMatrix[i, i] = i;
            } 

            Assert.AreEqual(nonUnitySquareMatrix.IsUnity(), false);
        }

        [TestMethod]
        public void doesIsUnityMethodWorkCorrectly4()
        {
            int diagonalLength = 3;
            Matrix nonUnitySquareMatrix = new Matrix(diagonalLength, 4);

            for (int i = 0; i < diagonalLength; i++)
            {
                nonUnitySquareMatrix[i, i] = i;
            } 

            Assert.AreEqual(nonUnitySquareMatrix.IsUnity(), false);
        }
    }
}