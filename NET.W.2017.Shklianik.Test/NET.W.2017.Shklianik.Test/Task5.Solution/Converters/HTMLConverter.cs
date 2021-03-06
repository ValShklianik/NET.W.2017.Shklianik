﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5.Solution.Converters
{
    public class HTMLConverter : Converter
    {
        public override void ConvertBoldText(BoldText boldText) =>
            this.Converted += "<b>" + boldText.Text + "</b>" + Environment.NewLine;

        public override void ConvertHyperlink(Hyperlink hyperlink) =>
            this.Converted += "<a href=\"" + hyperlink.Url + "\">" + hyperlink.Text + "</a>"
                        + Environment.NewLine;

        public override void ConvertPlainText(PlainText plainText) =>
            this.Converted += plainText.Text + Environment.NewLine;
    }
}
