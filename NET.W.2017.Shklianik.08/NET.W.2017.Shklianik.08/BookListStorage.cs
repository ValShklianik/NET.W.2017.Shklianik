using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

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

    #region class BookListStorage
    public class BookListStorage : IBookStorage
    { 
        #region private field path
        private string path;
        #endregion !foeld

        #region ctor BookListStorage
        /// <summary>
        /// Initializes an instance of storage with the passed parameter.
        /// </summary>
        /// <param name="path">book isbn</param>
        public BookListStorage(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentException("file title error :( ");
            }

            this.path = path;
        }
        #endregion !BookListStorage

        #region Save method
        /// <inheritdoc />
        public void Save(IEnumerable<Book> books)
        {
            using (Stream stream = File.OpenWrite(path))
            {
                var binaryFormatter = new BinaryFormatter();
                /*foreach(var book in books)
                {
                    binaryFormatter.Serialize(stream, book);
                }*/
                binaryFormatter.Serialize(stream, books);
            }
        }
        #endregion !Save

        #region GetBooks method
        /// <inheritdoc />
        public IEnumerable<Book> GetBooks()
        {
            if (!File.Exists(path))
            {
                throw new BookStorageException("binaryStorage engine panic: file is not exist");
            }

            var bookList = new List<Book>();
            using (Stream stream = File.OpenRead(path))
            {
                var binaryFormatter = new BinaryFormatter();
                bookList = (List<Book>)binaryFormatter.Deserialize(stream);
            }

            return bookList;
        }
        #endregion !GetBooks
    }
    #endregion !class

    #region class BookStorageException
    /// <inheritdoc />
    /// <summary>
    /// The exception by storage.
    /// </summary>
    public class BookStorageException : Exception
    {
        /// <inheritdoc />
        public BookStorageException(string message) : base (message) { }

    }
    #endregion !BookStorageException
}

