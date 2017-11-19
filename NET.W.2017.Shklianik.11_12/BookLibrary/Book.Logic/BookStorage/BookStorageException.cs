using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Logic
{
    #region class BookStorageException
    /// <inheritdoc />
    /// <summary>
    /// The exception by storage.
    /// </summary>
    public class BookStorageException : Exception
    {
        /// <inheritdoc />
        public BookStorageException(string message) : base(message)
        {
        }
    }
    #endregion !BookStorageException
}
