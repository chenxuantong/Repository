using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAlgorithm001
{
    class Program
    {
        static void Main()
        {
            int[] arrayToSort = new int[] { 15, 4, 1, 29, 107, 56, 11, 22 };
            int temporaryInt;

            for (int passCount = 1; passCount < arrayToSort.Length; passCount++)
            {
                for (int i = 0; i < arrayToSort.Length - 1; i++)
                {
                    if (arrayToSort[i] > arrayToSort[i + 1])
                    {
                        temporaryInt = arrayToSort[i];
                        arrayToSort[i] = arrayToSort[i + 1];
                        arrayToSort[i + 1] = temporaryInt;
                    }
                }
            }
        }
    }
}
