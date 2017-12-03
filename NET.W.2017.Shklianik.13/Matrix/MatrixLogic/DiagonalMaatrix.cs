namespace MatrixLogic
{
    public class DiagonalMatrix<T> : SquareMatrix<T>
    {
        #region ctors
        /// <summary>
        /// ctor order
        /// </summary>
        /// <param name="order"></param>
        public DiagonalMatrix(int order) : base(order)
        {
            matrix = new T[order];
        }

        /// <summary>
        /// ctor T[,]
        /// </summary>
        /// <param name="matrix"></param>
        public DiagonalMatrix(T[,] matrix) : base(matrix)
        {
            this.matrix = new T[order + 1];
           
            for (int i = 0;  i < order; i++)
            {
                this.matrix[GetIndex(i, i)] = matrix[i, i];
            }

            this.matrix[GetIndex(0, 1)] = matrix[0, 1];
        }

        /// <summary>
        /// ctor matrix
        /// </summary>
        /// <param name="matrix"></param>
        public DiagonalMatrix(SquareMatrix<T> matrix) : base(matrix)
        {
            this.matrix = new T[order + 1];

            for (int i = 0; i < order; i++)
            {
                this.matrix[GetIndex(i, i)] = matrix[i, i];
            }

            this.matrix[GetIndex(0, 1)] = matrix[0, 1];
        }
        #endregion !ctors

        /// <summary>
        /// gets index of matrix
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns>index </returns>
        protected sealed override int GetIndex(int i, int j)
        {
            if (i == j) return i;
            return order;
        }       
    }
}
