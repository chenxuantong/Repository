using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDS008.IComparerDemo
{
    class Program
    {
        static void Main()
        {
            var myAL = new ArrayList();
            myAL.Add("The");
            myAL.Add("quick");
            myAL.Add("brown");
            myAL.Add("fox");
            myAL.Add("jumps");
            myAL.Add("over");
            myAL.Add("the");
            myAL.Add("lazy");
            myAL.Add("dog");

            Console.WriteLine("显示原始的数组内的元素的值:");
            PrintIndexAndValues(myAL);

            myAL.Sort();
            Console.WriteLine("显示使用缺省的排序方法 Sort() 之后的值:");
            PrintIndexAndValues(myAL);

            IComparer myComparer = new myReverserClass();
            myAL.Sort(myComparer);
            Console.WriteLine("显示使用自定义的排序方法之后的值:");
            PrintIndexAndValues(myAL);

            Console.ReadKey();
        }

        public static void PrintIndexAndValues(IEnumerable myList)
        {
            int i = 0;
            foreach (Object obj in myList)
                Console.WriteLine("\t[{0}]:\t{1}", i++, obj);
            Console.WriteLine();
        }

    }

    public class myReverserClass : IComparer
    {
        int IComparer.Compare(Object x, Object y)
        {
            return ((new CaseInsensitiveComparer()).Compare(y, x));
        }

    }
}
