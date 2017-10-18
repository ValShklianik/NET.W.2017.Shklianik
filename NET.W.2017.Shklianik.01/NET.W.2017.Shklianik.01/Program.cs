using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NET.W._2017.Shklianik._01.Sorts;

namespace NET.W._2017.Shklianik._01
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] unsortedArr = { 4, 6, 1, 22, 3, 2, 9, 8, 66, 9, 6, 3 };
             QuickSort.Sort(unsortedArr);
            foreach (int element in unsortedArr)
            {
                System.Console.Write(element + ",");
            }
            Console.WriteLine();

            int[] unsortedArr2 = { 4, 77, 33, 11, 2, 6, 8, 09, 6, 3, 2 };
            MergeSort.Sort(unsortedArr2);
            foreach (int element in unsortedArr2)
            {
                System.Console.Write(element + ",");
            }
           

        }
    }


    
}
