using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLogic
{
    class MatrixExtension
    {
        public static SquareMatrix<T> Add<T>(SquareMatrix<T> matrixFirst, SquareMatrix<T> matrixSecond)
        {
            var resultArray = new T[matrixFirst.Order, matrixFirst.Order];

            for (int i = 0; i < matrixFirst.Order; i++)
            {
                for (int j = 0; j < matrixFirst.Order; j++)
                {
                    resultArray[i, j] = (dynamic)matrixFirst[i, j] + (dynamic)matrixFirst[i, j];
                }
            }

            return new SquareMatrix<T>(resultArray);
        }

        public static SquareMatrix<T> Add<T>(SquareMatrix<T> mFirst, DiagonalMatrix<T> mSecond)
        {
            var result = new SquareMatrix<T>(mFirst);

            for (int i = 0; i < result.Order; i++)
            {
                result[i, i] = (dynamic)result[i, i] + (dynamic)mSecond[i, i];
            }

            return result;
        }

        public static SquareMatrix<T> Add<T>(DiagonalMatrix<T> mFirst, SquareMatrix<T> mSecond) => Add<T>(mSecond, mFirst);

        public static SquareMatrix<T> Add<T>(SquareMatrix<T> mFirst, SymmetricMatrix<T> mSecond)
        {
            var resultArray = new T[mFirst.Order, mFirst.Order];

            for (int i = 0; i < mFirst.Order; i++)
            {
                for (int j = i; j < mFirst.Order; j++)
                {
                    resultArray[i, j] = (dynamic)mFirst[i, j] + (dynamic)mFirst[i, j];
                    resultArray[j, i] = (dynamic)mFirst[j, i] + (dynamic)mFirst[i, j];
                }
            }

            return new SquareMatrix<T>(resultArray);
        }

        public static SquareMatrix<T> Add<T>(SymmetricMatrix<T> mFirst, SquareMatrix<T> mSecond) => Add<T>(mSecond, mFirst);

        public static DiagonalMatrix<T> Add<T>(DiagonalMatrix<T> mFirst, DiagonalMatrix<T> mSecond)
        {
            var resultArray = new T[mFirst.Order, mFirst.Order];

            for (int i = 0; i < mFirst.Order; i++)
            {
                resultArray[i, i] = (dynamic)mFirst[i, i] + (dynamic)mFirst[i, i];
            }

            return new DiagonalMatrix<T>(resultArray);
        }

        public static SymmetricMatrix<T> Add<T>(DiagonalMatrix<T> mFirst, SymmetricMatrix<T> mSecond)
        {
            var result = new SymmetricMatrix<T>(mSecond);

            for (int i = 0; i < mFirst.Order; i++)
            {
                result[i, i] = (dynamic)mFirst[i, i] + (dynamic)result[i, i];
            }

            return result;
        }

        public static SymmetricMatrix<T> Add<T>(SymmetricMatrix<T> mFirst, DiagonalMatrix<T> mSecond) => Add<T>(mSecond, mFirst);


    }
}
