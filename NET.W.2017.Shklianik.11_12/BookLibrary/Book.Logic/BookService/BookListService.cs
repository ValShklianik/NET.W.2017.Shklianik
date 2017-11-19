using System;
using System.Collections.Generic;
using System.Linq;

namespace Book.Logic
{

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
