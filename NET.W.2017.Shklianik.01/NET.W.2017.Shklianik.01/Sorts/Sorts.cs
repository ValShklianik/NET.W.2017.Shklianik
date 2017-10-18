using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.W._2017.Shklianik._01.Sorts
{
    class QuickSort
    {

        public static void Sort(int[] elements)
        {
             Quicksort(elements, 0, elements.Length - 1);
        }

        private static void Quicksort(int[] elements, int left, int right)
        {
            int i = left, j = right;
            int pivot = elements[(left + right) / 2];

            while (i <= j)
            {
                while (elements[i] < pivot)
                {
                    i++;
                }

                while (elements[j] > pivot)
                {
                    j--;
                }

                if (i <= j)
                {
                    // Swap
                    int tmp = elements[i];
                    elements[i] = elements[j];
                    elements[j] = tmp;

                    i++;
                    j--;
                }
            }

            // Recursive calls
            if (left < j)
            {
                Quicksort(elements, left, j);
            }

            if (i < right)
            {
                Quicksort(elements, i, right);
            }

            
        }

    }

    class MergeSort
    {
        public static void Sort(int[] elements)
        {
            Mergesort(elements, 0, elements.Length - 1);
        }

        private static void Mergesort( int[] elements, int left, int right)
        {
            if (left < right)
            {
                int middle = (left + right) / 2;
                Mergesort( elements,left, middle);
                Mergesort( elements, middle + 1, right);
                Merge( elements,left, middle, right);
            }
        }

        private static void Merge( int[] elements, int left, int middle, int right)
        {
            int lengthLeft = middle - left + 1;
            int lengthRight = right - middle;
            int[] leftArr = new int[lengthLeft + 1];
            int[] rightArr = new int[lengthRight + 1];
            for (int i = 0; i < lengthLeft; i++)
            {
                leftArr[i] = elements[left + i];
            }
            for (int j = 0; j < lengthRight; j++)
            {
                rightArr[j] = elements[middle + j +1];
            }
            leftArr[lengthLeft] = Int32.MaxValue;
            rightArr[lengthRight] = Int32.MaxValue;
            int iIndex = 0;
            int jIndex = 0;
            for (int k = left; k <= right; k++)
            {
                if (leftArr[iIndex] <= rightArr[jIndex])
                {
                    elements[k] = leftArr[iIndex];
                    iIndex++;
                }
                else
                {
                    elements[k] = rightArr[jIndex];
                    jIndex++;
                }
            }
        }
    }
}
