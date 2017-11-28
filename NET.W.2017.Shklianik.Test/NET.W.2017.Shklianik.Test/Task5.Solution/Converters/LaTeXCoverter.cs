using System;

namespace Task5.Solution.Converters
{
    public class LaTeXCoverter : Converter
    {
        public override void ConvertBoldText(BoldText boldText)
        {
            Converted += "\\textbf{" + boldText.Text + "}" + Environment.NewLine;
        }

        public override void ConvertHyperlink(Hyperlink hyperlink)
        {
            Converted += "\\href{" + hyperlink.Url + "}{" + hyperlink.Text + "}" + Environment.NewLine;

        }

        public override void ConvertPlainText(PlainText plainText)
        {
            Converted += plainText.Text + Environment.NewLine;
        }
    }
}

