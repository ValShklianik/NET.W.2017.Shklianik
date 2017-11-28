using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLogic
{
    public class DiagonalMatrix<T> : SquareMatrix<T>
    {
        public DiagonalMatrix(int order) : base(order)
        {
            matrix = new T[order];
        }

        public DiagonalMatrix(T[,] matrix) : base(matrix)
        {
            this.matrix = new T[order + 1];
           
            for (int i = 0;  i < order; i++)
            {
                this.matrix[GetIndex(i, i)] = matrix[i, i];
            }

            this.matrix[GetIndex(0, 1)] = matrix[0, 1];
        }

        protected override int GetIndex(int i, int j)
        {
            if (i == j) return i;
            return order;
        }
    
        public DiagonalMatrix(SquareMatrix<T> matrix) : base(matrix)
        {
            this.matrix = new T[order + 1];

            for (int i = 0; i < order; i++)
            {
                this.matrix[GetIndex(i, i)] = matrix[i, i];
            }

            this.matrix[GetIndex(0, 1)] = matrix[0, 1]; 
        }
    }
}
