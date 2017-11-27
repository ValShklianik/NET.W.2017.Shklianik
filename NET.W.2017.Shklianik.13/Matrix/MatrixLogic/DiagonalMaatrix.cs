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
        }

        public DiagonalMatrix(SquareMatrix<T> matrix) : base(matrix)
        {
        }
    }
}
