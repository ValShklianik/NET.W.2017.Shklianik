using System;

namespace BinarySearchLogic
{
#region public static claass BinarySearch
    public static class BinarySearch
    {
        #region public static Find
        /// <summary>
        /// finds index of required element 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="required"></param>
        /// <param name="type"></param>
        /// <returns>index of required element </returns>
        public static int Find<T>(T[] array, T required,  Comparison<T> type)
        {
            if (array == null || required == null || type == null) throw new ArgumentNullException(nameof(array));
            
            if (array.Length == 0) return -1;

            int mid = GetMid(array);
            int index = 0;
            if (mid < 0) return -1;

            if (type(array[mid], required) > 0) return Find(SubArray(array, 0, mid - 1), required, type);
            if (type(array[mid], required) < 0)
            {
                index = Find(SubArray(array, mid + 1, array.Length - 1), required, type);
                if (index == -1)
                {
                    return index;
                }

                return index + mid + 1;
            }

            return mid;
        }
#endregion

        /// <summary>
        /// finds index of the midlle element
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <returns>midlle element</returns>
        private static int GetMid<T>(T[] array) => array.Length / 2;

        /// <summary>
        /// return subarray
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        #region private SubArray
        private static T[] SubArray<T>(T[] array, int start, int end)
        {
            T[] result = new T[end - start + 1];
            Array.Copy(array, start, result, 0, result.Length);
            return result;
        }
        #endregion 
    }
#endregion
}