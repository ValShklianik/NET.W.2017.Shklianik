namespace MatrixLogic
{
    public class SymmetricMatrix<T> : SquareMatrix<T>
    {
        #region ctrors

        /// <summary>
        /// ctor oder
        /// </summary>
        /// <param name="order"></param>
        public SymmetricMatrix(int order) : base(order)
        {
            matrix = new T[order];
        }

        /// <summary>
        /// ctror T[,]
        /// </summary>
        /// <param name="matrix"></param>
        public SymmetricMatrix(T[,] matrix) : base(matrix)
        {
            int matrixLength = ((1 + order) / 2) * order;
            this.matrix = new T[matrixLength];
            
            for (int i = 0; i < order; i++)
            {
                for (int j = 0; j < order; j++)
                {
                    int index = GetIndex(i, j);
                    this.matrix[index] = matrix[i, j];
                }
            }
        }

        /// <summary>
        /// ctor SquareMAtrix matrix
        /// </summary>
        /// <param name="matrix"></param>
        public SymmetricMatrix(SquareMatrix<T> matrix) : base(matrix)
        {
            int matrixLength = ((1 + order) / 2) * order;
            this.matrix = new T[matrixLength];

            for (int i = 0; i < order; i++)
            {
                for (int j = 0; j < order; j++)
                {
                    int index = GetIndex(i, j);
                    this.matrix[index] = matrix[i, j];
                }
            }
        }
        #endregion !ctrors

        /// <summary>
        /// gets inges of matrix
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns>index</returns>
        protected sealed override int GetIndex(int i, int j)
        {
            if ( j<=i) return (1+i)/2*i +j;
            return GetIndex(j,i);
        }
    }
}
