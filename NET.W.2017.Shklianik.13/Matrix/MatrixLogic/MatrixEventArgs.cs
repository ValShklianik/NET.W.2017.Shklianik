using System;

namespace MatrixLogic
{
    /// <inheritdoc />
    /// <summary>
    /// Class representing the arguments of the event by changing the cell of the matrix.
    /// </summary>
    /// <typeparam name="T">Matrix element type.</typeparam>
    public class MatrixEventArgs<T> : EventArgs
    {
        /// <inheritdoc />
        /// <summary>
        /// Initializes an instance of the class with the passed parameters.
        /// </summary>
        /// <param name="row">matrix element row</param>
        /// <param name="column">matrix element column</param>
        /// <param name="oldValue">matrix element old value</param>
        /// <param name="newValue">matrix element new value</param>
        public MatrixEventArgs(int row, int column, T oldValue, T newValue)
        {
            Row = row;
            Column = column;
            OldValue = oldValue;
            NewValue = newValue;
        }

        /// <summary>
        /// Matrix element row.
        /// </summary>
        public int Row { get; }

        /// <summary>
        /// Matrix element column.
        /// </summary>
        public int Column { get; }

        /// <summary>
        /// Matrix element old value.
        /// </summary>
        public T OldValue { get; }

        /// <summary>
        /// Matrix element new value.
        /// </summary>
        public T NewValue { get; }
    }
}
