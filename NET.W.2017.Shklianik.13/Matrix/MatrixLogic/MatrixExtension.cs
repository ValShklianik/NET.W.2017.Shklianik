namespace MatrixLogic
{
    public static class MatrixExtension
    {
        #region public static add methods
        /// <summary>
        /// add a square matrix to a square
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="matrixFirst"></param>
        /// <param name="matrixSecond"></param>
        /// <returns>square matrix</returns>
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

        /// <summary>
        /// add a square matrix to a diagonal
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="matrixFirst"></param>
        /// <param name="matrixSecond"></param>
        /// <returns>square matrix</returns>
        public static SquareMatrix<T> Add<T>(SquareMatrix<T> mFirst, DiagonalMatrix<T> mSecond)
        {
            var result = new SquareMatrix<T>(mFirst);

            for (int i = 0; i < result.Order; i++)
            {
                result[i, i] = (dynamic)result[i, i] + (dynamic)mSecond[i, i];
            }

            return result;
        }

        /// <summary>
        /// add a diagolan matrix to a square
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="matrixFirst"></param>
        /// <param name="matrixSecond"></param>
        /// <returns>square matrix</returns>
        public static SquareMatrix<T> Add<T>(DiagonalMatrix<T> mFirst, SquareMatrix<T> mSecond) => Add<T>(mSecond, mFirst);

        /// <summary>
        /// add a square matrix to a symeric
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="matrixFirst"></param>
        /// <param name="matrixSecond"></param>
        /// <returns>square matrix</returns>
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

        /// <summary>
        /// add a symettric matrix to a square
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="matrixFirst"></param>
        /// <param name="matrixSecond"></param>
        /// <returns>square matrix</returns>
        public static SquareMatrix<T> Add<T>(SymmetricMatrix<T> mFirst, SquareMatrix<T> mSecond) => Add<T>(mSecond, mFirst);

        /// <summary>
        /// add a diagonal matrix to a diagal
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="matrixFirst"></param>
        /// <param name="matrixSecond"></param>
        /// <returns>diagonal matrix</returns>
        public static DiagonalMatrix<T> Add<T>(DiagonalMatrix<T> mFirst, DiagonalMatrix<T> mSecond)
        {
            var resultArray = new T[mFirst.Order, mFirst.Order];

            for (int i = 0; i < mFirst.Order; i++)
            {
                resultArray[i, i] = (dynamic)mFirst[i, i] + (dynamic)mFirst[i, i];
            }

            return new DiagonalMatrix<T>(resultArray);
        }

        /// <summary>
        /// add a diagonal matrix to a symetric
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="matrixFirst"></param>
        /// <param name="matrixSecond"></param>
        /// <returns>symetric matrix</returns>
        public static SymmetricMatrix<T> Add<T>(DiagonalMatrix<T> mFirst, SymmetricMatrix<T> mSecond)
        {
            var result = new SymmetricMatrix<T>(mSecond);

            for (int i = 0; i < mFirst.Order; i++)
            {
                result[i, i] = (dynamic)mFirst[i, i] + (dynamic)result[i, i];
            }

            return result;
        }

        /// <summary>
        /// add a symetric matrix to a diagonal
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="matrixFirst"></param>
        /// <param name="matrixSecond"></param>
        /// <returns>symetric matrix</returns>
        public static SymmetricMatrix<T> Add<T>(SymmetricMatrix<T> mFirst, DiagonalMatrix<T> mSecond) => Add<T>(mSecond, mFirst);
        #endregion !add
    }
}
