using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5.Solution.Converters
{
    public abstract class Converter 
    {
        public string Converted { get; protected set; } = string.Empty;

        public abstract void ConvertBoldText(BoldText boldText);

        public abstract void ConvertHyperlink(Hyperlink hyperlink);

        public abstract void ConvertPlainText(PlainText plainText);
    }
}
