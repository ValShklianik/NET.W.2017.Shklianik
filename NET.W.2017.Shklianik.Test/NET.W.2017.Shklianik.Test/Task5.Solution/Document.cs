using System;
using System.Collections.Generic;
using Task5.Solution.Converters;

namespace Task5
{
    public class Document
    {
        private List<DocumentPart> parts;

        public Document(IEnumerable<DocumentPart> parts)
        {
            if (parts == null)
            {
                throw new ArgumentNullException(nameof(parts));
            }
            this.parts = new List<DocumentPart>(parts);
        }

        public string Convert(Converter converter)
        {
            foreach(var part in parts)
            {
                part.Convert(converter);
            }

            return converter.Converted;
        }

        
    }
}
