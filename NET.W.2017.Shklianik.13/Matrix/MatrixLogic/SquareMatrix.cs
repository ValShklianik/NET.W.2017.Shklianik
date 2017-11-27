using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLogic
{
    public class SquareMatrix<T> : IEnumerable<T>, IEnumerable
    {
        protected readonly int order;
        protected T[] matrix;

        public event EventHandler<MatrixEventArgs<T>> OnChangeValue = delegate { };

        public SquareMatrix(int order)
        {
            if (order <= 0) throw new ArgumentException($"{nameof(order)} less then 0");
            this.order = order;
            this.matrix = new T[order * order];
        }

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
            for (int i = 0; i <= order; i++)
            {
                for (int j = 0; j <= order; j++)
                {
                    this.matrix[GetIndex(i, j)] = matrix[i, j];
                }
            }
        }

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

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Order; i++)
            {
                for (int j = 0; j < this.Order; j++)
                {
                    yield return this.GetValue(i, j);
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        protected virtual int GetIndex(int i, int j)
        {
            return (i * order) + j;
        }

        private void VerifyMatrix(int i, int j)
        {
            if (i > order || i <= 0 || j > order || j <= 0) throw new ArgumentException("coords is error");
        }

        private T GetValue(int i, int j)
        {
            return matrix[GetIndex(i, j)];
        }

        private void SetValue(T value, int i, int j)
        {
            matrix[GetIndex(i, j)] = value;
        }

       

    }
}
