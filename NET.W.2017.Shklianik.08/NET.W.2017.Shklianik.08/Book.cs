using System;
using System.Text.RegularExpressions;

namespace Book.Logic
{
    #region Book class
    [Serializable]
    public class Book : IComparable, IComparable<Book>, IEquatable<Book>
    {
        #region fields
        private string isbn;
        private string author;
        private string title;
        private string publisher;
        private int year;
        private int numPages;
        private decimal price;
        #endregion
        #region constructor
        /// <summary>
        /// Initializes an instance of the book.
        /// </summary>
        public Book()
        {
            isbn = null;
            author = null;
            title = null;
            publisher = null;
            year = 0;
            numPages = 0;
            price = 0;
        }

        public Book(string isbn, string author, string title, string publisher, int year, int numPages, decimal price)
        {
            ISBN = isbn;
            Author = author;
            Title = title;
            Publisher = publisher;
            Year = year;
            NumPages = numPages;
            Price = price;
        }

        #endregion
        #region properties
        /// <summary>
        /// International standard book number.
        /// </summary>
        /// <exception cref="ArgumentException">
        /// Thrown when <param name="value"/> error.
        /// </exception>
        public string ISBN
        {
            get
            {
                return isbn;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("ISBN value error");
                }

                var regException = new Regex("(ISBN[-]*(1[03])*[ ]*(: ){0,1})*(([0-9Xx][- ]*){13}|([0-9Xx][- ]*){10})");
                if (!regException.IsMatch(value))
                {
                    throw new ArgumentException("ISBN format error");
                }

                isbn = value;
            }
        }

        /// <summary>
        /// Author of the book.
        /// </summary>
        /// <exception cref="ArgumentException">
        /// Thrown when <param name="value"/> error.
        /// </exception>
        public string Author
        {
            get => author;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Author value error");
                }

                author = value;
            }
        }

        /// <summary>
        /// Name of the book.
        /// </summary>
        /// <exception cref="ArgumentException">
        /// Thrown when <param name="value"/> error.
        /// </exception>
        public string Title
        {
            get
            {
                return title;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name value error");
                }

                title = value;
            }
        }

        /// <summary>
        /// PubLIsh house of the book.
        /// </summary>
        /// <exception cref="ArgumentException">
        /// Thrown when <param name="value"/> error.
        /// </exception>
        public string Publisher
        {
            get
            {
                return publisher;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Publish House value error");
                }

                publisher = value;
            }
        }

        /// <summary>
        /// Year of publish.
        /// </summary>
        /// <exception cref="ArgumentException">
        /// Thrown when <param name="value"/> error.
        /// </exception>
        public int Year
        {
            get
            {
                return year;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Year error");
                }

                year = value;
            }
        }

        /// <summary>
        /// Number of pages.
        /// </summary>
        /// <exception cref="ArgumentException">
        /// Thrown when <param name="value"/> error.
        /// </exception>
        public int NumPages
        {
            get
            {
                return numPages;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Number of pages error");
                }

                numPages = value;
            }
        }

        /// <summary>
        /// Price of the book.
        /// </summary>
        /// <exception cref="ArgumentException">
        /// Thrown when <param name="value"/> error.
        /// </exception>
        public decimal Price
        {
            get
            {
                return price;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("price error");
                }

                price = value;
            }
        }
        #endregion
        #region override methods

        /// <summary>
        /// override ToString() methods.
        /// </summary>
        /// <returns>String representation.</returns>
        public override string ToString() => $"{ISBN}, Aythor: {Author}, Name: {Title}, Publish House: {Publisher}, Year: {Year}, Number of pages: {NumPages}, Price: {Price}";

        /// <summary>
        /// override Equals() methods.
        /// </summary>
        /// <param name="obj">object to compare</param>
        /// <returns>True if objects are equivalent, false otherwise</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            return obj.GetType() == GetType() && this.Equals((Book)obj);
        }

        /// <summary>
        /// override Equals() methods.
        /// </summary>
        /// <returns>Hash code with isbn, publish house,  year, name divided by 4</returns>
        public override int GetHashCode()
        {
            return (ISBN.GetHashCode()
              + Publisher.GetHashCode()
              + Year.GetHashCode()
              + Title.GetHashCode()) / 4;
        }
        #endregion
        #region interface implementation

        public int CompareTo(object obj)
        {
            if (ReferenceEquals(obj, null))
            {
                return 1;
            }

            return obj.GetType() != GetType() ? 1 : CompareTo((Book)obj);
        }

        /// <inheritdoc />
        /// <summary>
        /// Compares two books by Author.
        /// </summary>
        /// <param name="other">book for comparison.</param>
        /// <returns>1 if greater, 0 if equal, -1 if less.</returns>
        public int CompareTo(Book book)
        {
            if (ReferenceEquals(this, book))
            {
                return 0;
            }

            return ReferenceEquals(book, null) ? 1 : string.Compare(Author, book.Author, StringComparison.CurrentCulture); 
        }

        /// <inheritdoc />
        /// <summary>
        /// Equals two books by ISBN code.
        /// </summary>
        /// <param name="other">book for comparison.</param>
        /// <returns>eq if isbn are eq.</returns>
        public bool Equals(Book book)
        {
            if (ReferenceEquals(this, book))
            {
                return true;
            }

            if (ReferenceEquals(null, book))
            {
                return false;
            }

            return book.ISBN == ISBN;
        }
#endregion
    }
}
#endregion