using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Logic
{
    #region interface IPredicate
    public interface IPredicate<T>
    {
        /// <summary>
        /// The method that decides the task of selecting an <paramref name="item"/>.
        /// </summary>
        /// <param name="item">element for analysis</param>
        /// <returns>True if <paramref name="item"/> is selected, false otherwise.</returns>
        bool Select(T item);
    }
    #endregion !IPredicate
}