using System;
using System.Collections.Generic;
using System.Linq;

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

    #region interface IPredicate
    public interface IPredicate<T>
    {
        /// <summary>
        /// The method that decides the task of selecting an <paramref name="item"/>.
        /// </summary>
        /// <param name="item">element for analysis</param>
        /// <returns>True if <paramref name="item"/> is selected, false otherwise.</returns>
        bool Select(T item);
    }
    #endregion !IPredicate

    #region class BookListService
    /// <inheritdoc />
    public class BookListService : IBookService
    {
        #region private fields
        private readonly IBookStorage storage;
        private readonly List<Book> books = new List<Book>();
        #endregion !fields

        #region Ctor BookListService
        /// <summary>
        /// Ctor of BookService with the passed parameter.
        /// </summary>
        /// <param name="bookStorage">Storage implementation.</param>
        public BookListService(IBookStorage storage)
        {
            if (ReferenceEquals(storage, null))
            {
                throw new ArgumentNullException("storage is null");
            }

            this.storage = storage;
        }
        #endregion

        #region interface implementation
        /// <inheritdoc />
        public void AddBook(Book book)
        {
            if (ReferenceEquals(book, null))
            {
                throw new ArgumentNullException("book is null");
            }

            books.Add(book);
        }

        /// <inheritdoc />
        public void AddBook(params Book[] booksParams)
        {
            if (ReferenceEquals(booksParams, null))
            {
                throw new ArgumentNullException("booksParams is null");
            }

            foreach (var book in booksParams)
            {
                books.Add(book);
            }
        }

        /// <inheritdoc />
        public void AddBook(IEnumerable<Book> books)
        {
            if (ReferenceEquals(books, null))
            {
                throw new ArgumentNullException("books is null");
            }

            foreach (var book in books)
            {
                this.books.Add(book);
            }
        }

        /// <inheritdoc />
        public IEnumerable<Book> FindBooks(IPredicate<Book> predicate)
        {
            if (ReferenceEquals(predicate, null))
            {
                throw new ArgumentNullException("predicate is null");
            }

            return books.Where(predicate.Select);
        }

        /// <inheritdoc />
        public void RemoveBook(Book book)
        {
            if (ReferenceEquals(book, null))
            {
                throw new ArgumentNullException("book is null");
            }

            books.Remove(book);
        }

        /// <inheritdoc />
        public void RemoveBook(IPredicate<Book> predicate)
        {
            if (ReferenceEquals(predicate, null))
            {
                throw new ArgumentNullException("predicate is null");
            }

            var booksForRemove = FindBooks(predicate);
            foreach (var book in booksForRemove)
            {
                books.Remove(book);
            }     
        }

        /// <inheritdoc />
        public IEnumerable<Book> GetBooks() => new List<Book>(books);

        /// <inheritdoc />
        public void Sort() => books.Sort();

        /// <inheritdoc />
        public void Sort(IComparer<Book> comparator) => books.Sort(comparator);

        /// <inheritdoc />
        public void Save() => storage.Save(books);
#endregion
    }
#endregion
}
