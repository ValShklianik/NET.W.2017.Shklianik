using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5.Solution.Converters
{
    public class PlainTextConverter : Converter
    {
        public override void ConvertBoldText(BoldText boldText) =>
            Converted += "**" + boldText.Text + "**" + Environment.NewLine;

        public override void ConvertHyperlink(Hyperlink hyperlink) =>
            Converted += hyperlink.Text + " [" + hyperlink.Url + "]" + Environment.NewLine;

        public override void ConvertPlainText(PlainText plainText) =>
            Converted += plainText.Text + Environment.NewLine;
    }
}
