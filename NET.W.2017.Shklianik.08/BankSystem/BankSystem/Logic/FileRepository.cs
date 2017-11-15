using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Account
{
    public class FileRepository : IRepository
    {
        public List<Account> repository = new List<Account>();
        public void Create(Account account)
        {
            repository.Add(account);
        }

        public IEnumerable<Account> Read()
        {
            if (!File.Exists(path))
            {
                File.Create(path);
            }

            var bookList = new List<Book>();
            using (Stream stream = File.OpenRead(path))
            {
                var binaryFormatter = new BinaryFormatter();
                bookList = (List<Book>)binaryFormatter.Deserialize(stream);
            }

            return bookList;
        }
    }

        private void Save(IEnumerable<Book> books)
        {
            using (Stream stream = File.OpenWrite(path))
            {
                var binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(stream, books);
            }
        }
    }

}
