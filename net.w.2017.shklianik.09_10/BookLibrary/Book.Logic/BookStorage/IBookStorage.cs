using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Logic
{
    #region interface IBookStorage
    /// <summary>
    /// Interface for storage.
    /// </summary>
    public interface IBookStorage
    {
        /// <summary>
        /// Returns all books.
        /// </summary>
        /// <returns>Books contained in the storage.</returns>
        IEnumerable<Book> GetBooks();

        /// <summary>
        /// Saves changes.
        /// </summary>
        /// <param name="books">Books to save</param>
        void Save(IEnumerable<Book> books);
    }
    #endregion !unterface
}
