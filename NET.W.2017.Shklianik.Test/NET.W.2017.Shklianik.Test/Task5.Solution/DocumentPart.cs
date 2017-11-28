using Task5.Solution.Converters;

namespace Task5
{
    public abstract class DocumentPart
    {
        public string Text { get; set; }

        public abstract void Convert(Converter converter);
    }
}
