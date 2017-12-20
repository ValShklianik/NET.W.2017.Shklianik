using System;

namespace DAL.Interface
{
    /// <inheritdoc />
    /// <summary>
    /// The exception thrown by repository in case of an error.
    /// </summary>
    public class RepositoryException : Exception
    {
        /// <inheritdoc />
        public RepositoryException()
        {
        }

        /// <inheritdoc />
        public RepositoryException(string message) :
            base(message)
        {
        }

        /// <inheritdoc />
        public RepositoryException(string message, Exception innerException) :
            base(message, innerException)
        {
        }
    }
}