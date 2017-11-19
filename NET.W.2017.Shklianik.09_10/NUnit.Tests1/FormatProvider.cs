using System;
using System.Globalization;

namespace NUnit.Tests1
{

    public class FormatProvider : IFormatProvider
    {
        private IFormatProvider cultureFormatProvider;
        public FormatProvider() : this(CultureInfo.CurrentCulture) { }
        public FormatProvider(IFormatProvider cultureFormatProvider)
        {
            if (ReferenceEquals(cultureFormatProvider, null))
            {
                throw new ArgumentNullException(nameof(cultureFormatProvider));
            }

            this.cultureFormatProvider = cultureFormatProvider;
        }

        public object GetFormat(Type formatType) => formatType == typeof(ICustomFormatter) ? this : null;

    }
}
