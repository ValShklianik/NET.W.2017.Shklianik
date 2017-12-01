using System;

namespace BinarySearchTreeLogic
{
    #region public struct
    public struct Point : IComparable<Point>
    {
        public int X;

        public int Y;

        #region ctor
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
        #endregion !ctor

        /// <inheritdoc />
        public int CompareTo(Point point)
        {
            return 0;
        }
    }
    #endregion
}
