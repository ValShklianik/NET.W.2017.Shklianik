using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Book.Logic
{

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
}