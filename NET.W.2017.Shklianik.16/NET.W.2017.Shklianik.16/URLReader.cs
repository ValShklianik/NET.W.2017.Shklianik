using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NET.W._2017.Shklianik._16
{
    public  class URLReader
    {
        private string filePath;

        public URLReader(string filePath)
        {
            this.filePath = filePath;
        }

        public IEnumerable<URLContainer> ReadFile()
        {
            foreach (string line in File.ReadLines(filePath))
            {
                var uri = new Uri(line);

            }
        }
    }
}
