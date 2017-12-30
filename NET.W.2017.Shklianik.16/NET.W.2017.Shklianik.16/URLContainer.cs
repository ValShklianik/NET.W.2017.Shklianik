using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.W._2017.Shklianik._16
{
    public class URLContainer
    {
        public string Scheme { get; set; }
        public string Hhost { get; set; }
        public IEnumerable<string> UrlPath { get; set; }
        public IDictionary<string, string>Pparameters { get; set; }
            

    }
}
