using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Logic
{
    class Program
    {
        static ILogging logging = new Logging("Program");
        public static void Main()
        {
      
            IBookStorage bookListStorage = new BookListStorage(@"library.bin");
            IBookService bookListService = new BookListService(bookListStorage);

            if (bookListService.GetBooks().Count() != 0)
            {
                ServiceImplementation(bookListService);
            }
            else
            {
                FileCreateImplementation(bookListService);
            }

            bookListService.Save();
            Console.ReadLine();
        }

        public class TitlePredicate : IPredicate<Book>
        {
            private string title;
            public TitlePredicate(string title)
            {
                this.title = title;
            }

            public bool Select(Book book)
            {
                return book.Title == title;
            }
        }


        private static void FileCreateImplementation(IBookService bookList)
        {
            List<Book> book = new List<Book>();
            for (int i = 0; i < 10; i++)
            {
                book.Add(new Book
                {
                    ISBN = $"123-4-56-123456-{i}",
                    Author = $"Author{i}{i}{i}",
                    Title = $"Book{i}{i}{i}",
                    Publisher = $"House{i}{i}{i}",
                    Year = i * 120,
                    NumPages = i * 50,
                    Price = (decimal)i
                });
            }

            bookList.AddBook(book);

            bookList.Sort();

            ShowBooks(bookList.GetBooks());


            ShowBooks(bookList.FindBooks(new TitlePredicate("Book333")));

            bookList.Save();
        }

        private static void ServiceImplementation(IBookService bookList)
        {
            ShowBooks(bookList.GetBooks());
            ShowBooks(bookList.FindBooks(new TitlePredicate("Book333")));

            bookList.RemoveBook(new TitlePredicate("Book666"));

            bookList.Sort();

            bookList.Save();
        }

        private static void ShowBooks(IEnumerable<Book> books)
        {
            foreach (var book in books)
            {
                Console.WriteLine(book);
                logging.Warning(book.ToString());

                logging.Error(book.ToString());

                logging.Info(book.ToString());

            }
        }





    }
}
