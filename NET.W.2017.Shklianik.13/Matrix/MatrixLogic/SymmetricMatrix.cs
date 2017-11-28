using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLogic
{
    class SymmetricMatrix<T> : SquareMatrix<T>
    {
        public SymmetricMatrix(int order) : base(order)
        {
            matrix = new T[order];
        }

        public SymmetricMatrix(T[,] matrix) : base(matrix)
        {
            this.matrix = new T[((1 + order) / 2) * order];
            int matrixLength = ((1 + order) / 2) * order;

            for (int i = 0; i < matrixLength; i++)
            {
                for (int j = 0; j < matrixLength; j++)
                {
                    this.matrix[GetIndex(i, j)] = matrix[i, j];
                }
            }
        }

        public SymmetricMatrix(SquareMatrix<T> matrix) : base(matrix)
        {
            this.matrix = new T[((1 + order) / 2) * order];
            int matrixLength = ((1 + order) / 2) * order;

            for (int i = 0; i < matrixLength; i++)
            {
                for (int j = 0; j < matrixLength; j++)
                {
                    this.matrix[GetIndex(i, j)] = matrix[i, j];
                }
            }
        }

        protected override int GetIndex(int i, int j)
        {
            if ( j<=i) return (1+i)/2*i +j;
            return GetIndex(j,i);
        }
    }
}
