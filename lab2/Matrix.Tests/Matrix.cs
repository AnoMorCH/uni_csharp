namespace Matrix.UnitTests
{
    [TestClass]
    public class MatrixUnitTests
    {
        [TestMethod]
        public void CreatedMatrixHasRightDimensions()
        {
            Matrix matrix = new Matrix(2, 4);
            Assert.AreEqual(2, matrix.columnsAmount);
            Assert.AreEqual(4, matrix.rowsAmount);
        }

        [TestMethod]
        public void MatrixIsInitiated()
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
        public void UnityMatrixIsUnityMatrix()
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
        public void NonUnitySquareMatrixIsNotUnityMatrix1()
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
        public void NonUnitySquareMatrixIsNotUnityMatrix2()
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
        public void NonSquareMatrixIsNotUnity()
        {
            int diagonalLength = 3;
            Matrix nonUnitySquareMatrix = new Matrix(diagonalLength, 4);

            for (int i = 0; i < diagonalLength; i++)
            {
                nonUnitySquareMatrix[i, i] = i;
            } 

            Assert.AreEqual(nonUnitySquareMatrix.IsUnity(), false);
        }

        [TestMethod]
        public void MatrixIsSymmetric()
        {
            Matrix symmetricSquareMatrixWEqualDiagonal = new Matrix(3, 3);

            symmetricSquareMatrixWEqualDiagonal[0, 0] = 1;
            symmetricSquareMatrixWEqualDiagonal[0, 1] = 6;
            symmetricSquareMatrixWEqualDiagonal[0, 2] = 5;
            symmetricSquareMatrixWEqualDiagonal[1, 0] = 6;
            symmetricSquareMatrixWEqualDiagonal[1, 1] = 1;
            symmetricSquareMatrixWEqualDiagonal[1, 2] = 7;
            symmetricSquareMatrixWEqualDiagonal[2, 0] = 5;
            symmetricSquareMatrixWEqualDiagonal[2, 1] = 7;
            symmetricSquareMatrixWEqualDiagonal[2, 2] = 1;

            Assert.AreEqual(symmetricSquareMatrixWEqualDiagonal.IsSymmetric(), true);
        }

        [TestMethod]
        public void SymmetricMatrixWithNotEqualDiagonalIsSymmetric()
        {
            Matrix symmetricSquareMatrixWNotEqualDiagonal = new Matrix(3, 3);

            symmetricSquareMatrixWNotEqualDiagonal[0, 0] = 1;
            symmetricSquareMatrixWNotEqualDiagonal[0, 1] = 6;
            symmetricSquareMatrixWNotEqualDiagonal[0, 2] = 5;
            symmetricSquareMatrixWNotEqualDiagonal[1, 0] = 6;
            symmetricSquareMatrixWNotEqualDiagonal[1, 1] = 2;
            symmetricSquareMatrixWNotEqualDiagonal[1, 2] = 7;
            symmetricSquareMatrixWNotEqualDiagonal[2, 0] = 5;
            symmetricSquareMatrixWNotEqualDiagonal[2, 1] = 7;
            symmetricSquareMatrixWNotEqualDiagonal[2, 2] = 3;

            Assert.AreEqual(symmetricSquareMatrixWNotEqualDiagonal.IsSymmetric(), true);
        }

        [TestMethod]
        public void NonSquareMatrixIsNotSymmetric()
        {
            Matrix nonSquaredMatrix = new Matrix(3, 2);

            nonSquaredMatrix[0, 0] = 1;
            nonSquaredMatrix[1, 0] = 3;
            nonSquaredMatrix[2, 0] = 4;
            nonSquaredMatrix[0, 1] = 3;
            nonSquaredMatrix[1, 1] = 2;
            nonSquaredMatrix[2, 1] = 4;

            Assert.AreEqual(nonSquaredMatrix.IsSymmetric(), false);
        }

        [TestMethod]
        public void SquaredButNotSymmetricMatrixIsNotSymmetric()
        {
            Matrix squaredNonSymmetricMatrix = new Matrix(2, 2);

            squaredNonSymmetricMatrix[0, 0] = 2;
            squaredNonSymmetricMatrix[1, 0] = 3;
            squaredNonSymmetricMatrix[0, 1] = 4;
            squaredNonSymmetricMatrix[1, 1] = 5;

            Assert.AreEqual(squaredNonSymmetricMatrix.IsSymmetric(), false);
        } 

        [TestMethod]
        public void MultiplyMatrixWithDouble()
        {
            Matrix matrix = new Matrix(2, 2);

            matrix[0, 0] = 1;
            matrix[1, 0] = 2.5;
            matrix[0, 1] = -1;
            matrix[1, 1] = 0;

            matrix = matrix * 2;

            Assert.AreEqual(matrix[0, 0], 2.0);
            Assert.AreEqual(matrix[1, 0], 5.0);
            Assert.AreEqual(matrix[0, 1], -2.0);
            Assert.AreEqual(matrix[1, 1], 0);
        }

        [TestMethod]
        public void MultiplyMatrixWithMatrix()
        {
            Matrix matrixA = new Matrix(3, 2);

            matrixA[0, 0] = 1;
            matrixA[1, 0] = 2;
            matrixA[2, 0] = 3;
            matrixA[0, 1] = 4;
            matrixA[1, 1] = 5;
            matrixA[2, 1] = 6;

            Matrix matrixB = new Matrix(1, 3);

            matrixB[0, 0] = 1;
            matrixB[0, 1] = 2;
            matrixB[0, 2] = 3;

            Matrix resultedMatrix = matrixA * matrixB;

            Assert.AreEqual(resultedMatrix[0, 0], 14);
            Assert.AreEqual(resultedMatrix[0, 1], 32);
        }

        [TestMethod]
        [ExpectedException(typeof(RankException))]
        public void MultiplyPoorlyMatrixWithMatrix()
        {
            Matrix matrixA = new Matrix(2, 2);

            matrixA[0, 0] = 1;
            matrixA[0, 1] = 2;
            matrixA[1, 0] = 3;
            matrixA[1, 1] = 4;

            Matrix matrixB = new Matrix(1, 1);

            matrixB[0, 0] = -1;

            Matrix resultedMatrix = matrixA * matrixB;
        }

        [TestMethod]
        public void ConvertMatrixExplicitly()
        {
            double[,] matrixBefore = new double[3, 2];
            matrixBefore[0, 0] = 1;
            matrixBefore[1, 0] = 2;
            matrixBefore[2, 0] = 3;
            matrixBefore[0, 1] = 4;
            matrixBefore[1, 1] = 5;
            matrixBefore[2, 1] = 6;

            Matrix matrixAfter = (Matrix)matrixBefore;

            Assert.AreEqual(matrixAfter[0, 0], 1);
            Assert.AreEqual(matrixAfter[1, 0], 2);
            Assert.AreEqual(matrixAfter[2, 0], 3);
            Assert.AreEqual(matrixAfter[0, 1], 4);
            Assert.AreEqual(matrixAfter[1, 1], 5);
            Assert.AreEqual(matrixAfter[2, 1], 6);
        }

        [TestMethod]
        public void GetTraceOfSquareMatrix()
        {
            Matrix matrix = new Matrix(2, 2);

            matrix[0, 0] = 1;
            matrix[1, 0] = 2;
            matrix[0, 1] = 3;
            matrix[1, 1] = 4;

            Assert.AreEqual(matrix.Trace(), 5);
        }

        [TestMethod]
        [ExpectedException(typeof(RankException))]
        public void GetTraceOfNotSquareMatrix()
        {
            Matrix matrix = new Matrix(2, 3);

            matrix[0, 0] = 1;
            matrix[1, 0] = 2;
            matrix[0, 1] = 3;
            matrix[1, 1] = 4;
            matrix[0, 2] = 5;
            matrix[1, 2] = 6;

            matrix.Trace();
        }

        [TestMethod]
        public void MakeMatrixAString()
        {
            Matrix matrix = new Matrix(2, 2);

            matrix[0, 0] = 1;
            matrix[1, 0] = 2;
            matrix[0, 1] = 3;
            matrix[1, 1] = 4;

            string expectedString = "1 2 \n 3 4 \n ";

            Assert.AreEqual(matrix.ToString(), expectedString);
        }

        [TestMethod]
        public void GetUnityMatrix()
        {
            Matrix matrix = Matrix.GetUnity(2);

            Assert.AreEqual(matrix[0, 0], 1);
            Assert.AreEqual(matrix[1, 0], 0);
            Assert.AreEqual(matrix[0, 1], 0);
            Assert.AreEqual(matrix[1, 1], 1);
        }
    }
}