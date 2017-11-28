using Task5.Solution.Converters;

namespace Task5
{
    public class BoldText : DocumentPart
    {
        public override void Convert(Converter converter)
        {
            converter.ConvertBoldText(this);
        }
    }
}