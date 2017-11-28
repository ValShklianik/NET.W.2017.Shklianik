using Task5.Solution.Converters;

namespace Task5
{
    public class PlainText : DocumentPart
    {
        public override void Convert(Converter converter)
        {
            converter.ConvertPlainText(this);
        }
    }
}
