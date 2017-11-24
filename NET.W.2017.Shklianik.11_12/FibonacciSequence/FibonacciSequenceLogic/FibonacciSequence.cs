using System;
using System.Collections.Generic;

namespace FibonacciSequenceLogic
{
    #region public class FibonacciSequence
    public static class FibonacciSequence
    {
        #region static IEnumerable
        /// <summary>
        /// generates Fibonacci Sequence
        /// </summary>
        /// <returns>next elemebt of sequence</returns>
        public static IEnumerable<int> GetFibSecuence(int length)
        {
            if (length <= 0) throw new ArgumentException(nameof(length));
            int currentEl = 0;
            int nextEl = 1;

            while (length > 0)
            {
                length--;
                yield return currentEl;
                int temp = currentEl + nextEl;
                currentEl = nextEl;

                nextEl = temp;
            }
        }
        #endregion
    }
    #endregion
}
