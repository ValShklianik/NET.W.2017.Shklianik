using NUnit.Framework;
using System.Collections;
using MatrixLogic;

namespace NUnit.MatixLogic.Tests
{
    [TestFixture]
    public class MatrixTest
    {
        public static IEnumerable AddSquaresMatrixPlusSquareMatrix
        {
            get
            {
                var arraySq = new[,] {{1, 2, 10}, {3, 4, 0}, {6, 8, 7}};
                yield return new TestCaseData(arraySq, new[,] { { 1, 2, 10 }, { 3, 4, 0 }, { 6, 8, 7 } }).Returns(new SquareMatrix<int>(new[,] { { 2, 4, 20 }, { 6, 8, 0 }, { 12, 16, 14 }}) );
                yield return new TestCaseData(arraySq, new[,] { { 4, 17, 0 }, { 3, 9, 11 }, { 4, 4, 4 } }).Returns(new SquareMatrix<int>(new[,] { { 5, 19, 10 }, { 6, 13, 11 }, { 10, 12, 11 } }));
                yield return new TestCaseData(arraySq, new[,] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } }).Returns(new SquareMatrix<int>(new[,] { { 1, 2, 10 }, { 3, 4, 0 }, { 6, 8, 7 } }));
            }
        }

        public static IEnumerable AddSquaresMatrixPlusDiagonaleMatrix
        {
            get
            {
                var arraySq = new[,] { { 1, 2, 10 }, { 3, 4, 0 }, { 6, 8, 7 } };
                yield return new TestCaseData(arraySq, new[,] { { 1, 0, 0 }, { 0, 4, 0 }, { 0, 0, 7 } }).Returns(new SquareMatrix<int>(new[,] { { 2, 2, 10 }, { 3, 8, 0 }, { 6, 8, 14 } }));
                yield return new TestCaseData(arraySq, new[,] { { 10, 0, 0 }, { 0, 1, 0 }, { 0, 0, 10 } }).Returns(new SquareMatrix<int>(new[,] { { 11, 2, 10 }, { 3, 5, 0 }, { 6, 8, 17 } }));
                yield return new TestCaseData(arraySq, new[,] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } }).Returns(new SquareMatrix<int>(new[,] { { 1, 2, 10 }, { 3, 4, 0 }, { 6, 8, 7 } }));
            }
        }

        public static IEnumerable AddSquaresMatrixPlusSymetricMatrix
        {
            get
            {
                var arraySq = new[,] { { 1, 2, 10 }, { 3, 4, 0 }, { 6, 8, 7 } };
                yield return new TestCaseData(arraySq, new[,] { { 1, 5, 0 }, { 5, 4, 1 }, { 0, 1, 8 } }).Returns(new SquareMatrix<int>(new[,] { { 2, 7, 10 }, { 8, 9, 1 }, { 6, 9, 15 } }));
                yield return new TestCaseData(arraySq, new[,] { { 10, 0, 0 }, { 0, 4, 0 }, { 0, 0, 9 } }).Returns(new SquareMatrix<int>(new[,] { { 11, 2, 10 }, { 3, 8, 0 }, { 6, 8, 16 } }));
                yield return new TestCaseData(arraySq, new[,] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } }).Returns(new SquareMatrix<int>(new[,] { { 1, 2, 10 }, { 3, 4, 0 }, { 6, 8, 7 } }));
            }
        }

        public static IEnumerable AddDiagonalMatrixPlusSymetricMatrix
        {
            get
            {
                var arraySq = new[,] { { 9, 0, 0 }, { 0, 4, 0 }, { 0, 0, 7 } };
                yield return new TestCaseData(arraySq, new[,] { { 1, 5, 0 }, { 5, 4, 1 }, { 0, 1, 8 } }).Returns(new SymmetricMatrix<int>(new[,] { { 10, 5, 0 }, { 5, 8, 1 }, { 0, 1, 15 } }));
                yield return new TestCaseData(arraySq, new[,] { { 10, 0, 0 }, { 0, 4, 0 }, { 0, 0, 9 } }).Returns(new SymmetricMatrix<int>(new[,] { { 19, 0, 0 }, { 0, 8, 0 }, { 0, 0, 16 } }));
                yield return new TestCaseData(arraySq, new[,] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } }).Returns(new SymmetricMatrix<int>(new[,] { { 9, 0, 0 }, { 0, 4, 0 }, { 0, 0, 7 } }));
            }
        }

        [Test, TestCaseSource(nameof(AddSquaresMatrixPlusSquareMatrix))]
        public SquareMatrix<int> AddSquaresMatrixTest(int[,] arr1, int[,] arr2)
        {
            var lhs = new SquareMatrix<int>(arr1);
            var rhs = new SquareMatrix<int>(arr1);
            return MatrixExtension.Add(lhs, rhs);            
        }

        [Test, TestCaseSource(nameof(AddSquaresMatrixPlusDiagonaleMatrix))]
        public SquareMatrix<int> AddSquaresMatrixPlusDiagonaleMatrixTest(int[,] arr1, int[,] arr2)
        {
            var lhs = new SquareMatrix<int>(arr1);
            var rhs = new DiagonalMatrix<int>(arr1);
            return MatrixExtension.Add(lhs, rhs);
        }

        [Test, TestCaseSource(nameof(AddSquaresMatrixPlusSymetricMatrix))]
        public SquareMatrix<int> AddSquaresMatrixPlusSymetricMatrixTest(int[,] arr1, int[,] arr2)
        {
            var lhs = new SquareMatrix<int>(arr1);
            var rhs = new SymmetricMatrix<int>(arr1);
            return MatrixExtension.Add(lhs, rhs);
        }

        [Test, TestCaseSource(nameof(AddDiagonalMatrixPlusSymetricMatrix))]
        public SquareMatrix<int> AddDiagonalMatrixPlusSymetricMatrixTest(int[,] arr1, int[,] arr2)
        {
            var lhs = new DiagonalMatrix<int>(arr1);
            var rhs = new SymmetricMatrix<int>(arr1);
            return MatrixExtension.Add(lhs, rhs);
        }



    }
}

