namespace Task5.Console
{
    using System.Collections.Generic;
    using System;
    using Task5.Solution.Converters;

    class Program
    {
        static void Main(string[] args)
        {
            List<DocumentPart> parts = new List<DocumentPart>
                {
                    new PlainText {Text = "Some plain text"},
                    new Hyperlink {Text = "google.com", Url = "https://www.google.by/"},
                    new BoldText {Text = "Some bold text"}
                };

            Document document = new Document(parts);

            Converter converterHTML = new HTMLConverter();
            Converter converterLaTeX = new LaTeXCoverter();
            Converter converterPlainText = new PlainTextConverter();


            Console.WriteLine(document.Convert(converterHTML));

            Console.WriteLine(document.Convert(converterLaTeX));

            Console.WriteLine(document.Convert(converterPlainText));
        }
    }
}
