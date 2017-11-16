using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Account
{

    public class FileRepository : IRepository
    {
        private string path;
        public List<Account> repository;


        public FileRepository(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentException("file title error :( ");
            }
            repository = new List<Account>();

            this.path = path;

        }

        public IEnumerable<Account> Read()
        {
            if (!File.Exists(path))
            {
                return new List<Account>();
            }

            using (Stream stream = File.OpenRead(path))
            {
                var binaryFormatter = new BinaryFormatter();
                repository = (List<Account>)binaryFormatter.Deserialize(stream);
            }

            return repository;
        }

        public void Save(IEnumerable<Account> accounts)
        {
            using (Stream stream = File.OpenWrite(path))
            {
                var binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(stream, accounts);
            }
        }
    }
}