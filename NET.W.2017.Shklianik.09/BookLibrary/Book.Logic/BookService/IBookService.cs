using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Logic
{
    #region interface IBookService
    /// <summary>
    /// Interface describing service.
    /// </summary>
    public interface IBookService
    {
        /// <summary>
        /// Adds a book to the storage.
        /// </summary>
        /// <param name="book">Book to add.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when an error occurred in service.
        /// </exception>
        void AddBook(Book book);

        /// <summary>
        /// Add params books to the storage.
        /// </summary>
        /// <params name="books">Books to add.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when an error occurred in service.
        /// </exception>
        void AddBook(params Book[] booksParams);

        void AddBook(IEnumerable<Book> books);

        /// <summary>
        /// Removes a book from storage.
        /// </summary>
        /// <param name="book">Book to remove</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when an error occurred in service.
        /// </exception>
        void RemoveBook(Book book);

        /// <summary>
        /// Removes a book from storage for choosing criterion.
        /// </summary>
        /// <param name="book">Book to remove</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when an error occurred in service.
        /// </exception>
        void RemoveBook(IPredicate<Book> predicate);

        /// <summary>
        /// Looks for books on a given <paramref name="predicate"/> in the storage.
        /// </summary>
        /// <param name="predicate">the criterion for choosing books</param>
        /// <returns>Found book for choosing criterion <returns>
        IEnumerable<Book> FindBooks(IPredicate<Book> predicate);

        /// <summary>
        /// Returns all books.
        /// </summary>
        /// <returns>All books contained in the storage.</returns>
        IEnumerable<Book> GetBooks();

        /// <summary>
        /// Sorts all books in the storage using interfase IComparable.
        /// </summary>
        void Sort();

        /// <summary>
        /// Sorts all books in the storage using comparator.
        /// </summary>
        /// <param name="comparator">criterion for sorting books.</param>
        void Sort(IComparer<Book> comparator);

        /// <summary>
        /// Save changes.
        /// </summary>
        void Save();
    }
    #endregion !IBookService
}
