using System;
using System.Collections.Generic;

namespace Test6.Solution
{
    public class SequenceGenerator<T>
    {
        public delegate T GetSequenceElement(T a, T b);
        public GetSequenceElement function;
        private T a;
        private T b;
        public SequenceGenerator(T a, T b, GetSequenceElement function)
        {
            this.function = function;
            this.a = a;
            this.b = b;
        }

        public IEnumerable<T> GetSequence(int length)
        {
            if (length <= 0) throw new ArgumentException(nameof(length));

            while (length > 0)
            {
                length--;
                yield return a;
                T temp = function(a, b);
                a = b;

                b = temp;
            }
        }

        public static T FirstFormula(T a, T b)
        {
            return (dynamic)a + (dynamic)b;
        }

        public static T SecondFormula(T a, T b)
        {
            return 6 * (dynamic)a - 8 * (dynamic)b;
        }

        public static T ThirdFormula(T a, T b)
        {
            return (dynamic)a + (dynamic)b / (dynamic)a;
        }
    }
}
