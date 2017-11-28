using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.Solution;

namespace Task2.Console
{
    class Program
    {
        public static void Main(string[] args)
        {
            RaandomFileGenerator fileGenerator = new RandomCharsFileGenerator("files_for_char", ".txt");
            fileGenerator.GenerateFiles(2, 42);
            RaandomFileGenerator fileGenerator1 = new RandomBytesFileGenerator("files_for_bytes", ".bin");
            fileGenerator1.GenerateFiles(2, 42);

        }
    }
}
