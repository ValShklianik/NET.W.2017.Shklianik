using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test6.Solution
{
    public class SequenceGenerator<T>
    {
        public delegate T GetSequenceElement(T a, T b);
        private GetSequenceElement function;
        private T a;
        private T b;
        public SequenceGenerator(T a, T b, GetSequenceElement function)
        {
            this.function = function;
            this.a = a;
            this.b = b;
        }
        public IEnumerable<T> GetSecuence(int length)
        {
            if (length <= 0) throw new ArgumentException(nameof(length));
            T currentEl = a;
            T nextEl = b;

            while (length > 0)
            {
                length--;
                yield return currentEl;
                T temp = function(a, b);
                currentEl = nextEl;

                nextEl = temp;
            }
        }
    }
}
