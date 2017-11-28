using Task5.Solution.Converters;

namespace Task5
{
    public class Hyperlink : DocumentPart
    {
        public string Url { get; set; }

        public override void Convert(Converter converter)
        {
            converter.ConvertHyperlink(this);
        }
            
    }
}
