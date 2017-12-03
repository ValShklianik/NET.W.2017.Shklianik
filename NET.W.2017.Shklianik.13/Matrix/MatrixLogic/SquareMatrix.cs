using System;
using System.Collections;
using System.Collections.Generic;

namespace MatrixLogic
{
    public class SquareMatrix<T> : IEnumerable<T>
    {
        #region protected fields
        protected readonly int order;
        protected T[] matrix;
        #endregion !fields

        #region event
        public event EventHandler<MatrixEventArgs<T>> OnChangeValue = delegate { };
        #endregion !event

        #region ctors
        /// <summary>
        /// ctor orde
        /// </summary>
        /// <param name="order"></param>
        public SquareMatrix(int order)
        {
            if (order <= 0) throw new ArgumentException($"{nameof(order)} less then 0");
            this.order = order;
            matrix = new T[order * order];
        }

        /// <summary>
        /// ctor matrix
        /// </summary>
        /// <param name="matrix"></param>
        public SquareMatrix(T[,] matrix)
        {
            if (ReferenceEquals(matrix, null))
            {
                throw new ArgumentNullException(nameof(matrix));
            }

            if (matrix.GetLength(0) != matrix.GetLength(1))
            {
                throw new ArgumentException($"{nameof(matrix)} is not square.");
            }

            order = matrix.GetLength(0);
            this.matrix = new T[order * order];
            for (int i = 0; i < order; i++)
            {
                for (int j = 0; j < order; j++)
                {
                    this.matrix[GetIndex(i, j)] = matrix[i, j];
                }
            }
        }

        /// <summary>
        /// ctor SquareMatrix matrix
        /// </summary>
        /// <param name="matrix"></param>
        public SquareMatrix(SquareMatrix<T> matrix)
        {
            if (ReferenceEquals(matrix, null)) throw new ArgumentNullException(nameof(matrix));
            order = matrix.Order;
            this.matrix = new T[order * order];
            for (int i = 0; i < order; i++)
            {
                for (int j = 0; j < order; j++)
                {
                    this[i, j] = matrix[i, j];
                }
            }
        }
        #endregion !ctors

        #region properties
        public int Order { get; }

        public T this[int i, int j]
        {
            get
            {
                VerifyMatrix(i, j);
                return GetValue(i, j);
            }

            set
            {
                VerifyMatrix(i, j);
                var oldValue = GetValue(i, j);
                SetValue(value, i, j);
                OnChangeValue(this, new MatrixEventArgs<T>(i, j, oldValue, value));
            }
        }
        #endregion !properties

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Order; i++)
            {
                for (int j = 0; j < Order; j++)
                {
                    yield return GetValue(i, j);
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <summary>
        /// gets index of matrix
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns>index</returns>
        protected virtual int GetIndex(int i, int j)
        {
            return (i * order) + j;
        }

        /// <summary>
        /// verifying matrix by square
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        private void VerifyMatrix(int i, int j)
        {
            if (i > order || i <= 0 || j > order || j <= 0) throw new ArgumentException("coords is error");
        }

        /// <summary>
        /// gets value of element
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns>value of matrix element</returns>
        private T GetValue(int i, int j)
        {
            return matrix[GetIndex(i, j)];
        }

        /// <summary>
        /// sets value of element
        /// </summary>
        /// <param name="value"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        private void SetValue(T value, int i, int j)
        {
            matrix[GetIndex(i, j)] = value;
        }
    }
}
