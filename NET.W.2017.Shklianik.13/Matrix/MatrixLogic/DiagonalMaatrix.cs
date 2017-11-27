using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLogic
{
    public class DiagonalMaatrix<T> : SquareMatrix<T>
    {
        private T[] diagonalsElements;
        public DiagonalMaatrix(int order) : base(order)
        {
            diagonalsElements = new T[order];
        }

        public DiagonalMaatrix(T[,] matrix) : base(matrix)
        {
        }

        public DiagonalMaatrix(SquareMatrix<T> matrix) : base(matrix)
        {
        }
    }
}
