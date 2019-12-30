using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDS018.Hanoi
{
    class Program
    {
        static int count = 0;   // 计数，总共搬动盘子的次数；
        static void PrintMove(char x, char y)
        {
            Console.WriteLine("{0}-->{1}", x, y);

        }

        /// <summary>
        /// 移动碟子
        /// </summary>
        /// <param name="n">需要移动的碟子数量</param>
        /// <param name="one">A 塔的标识</param>
        /// <param name="two">B 塔的标识</param>
        /// <param name="three">C 塔的标识</param>
        static void Hanoi(int n, char one, char two, char three)
        {
            if (n == 1)
            {
                ++count;
                PrintMove(one, three);

            }
            else
            {
                ++count;
                // 借助B塔把第N个盘上面(n-1)个盘子的搬移到另一个盘；
                Hanoi(n - 1, one, three, two);
                // 打印第N个盘移到目标塔的步骤；
                PrintMove(one, three);
                // 借助B塔把原来第N个盘子上面的（n-1）个盘子搬到现在第 N 个盘子所在的塔上;
                Hanoi(n - 1, two, one, three);
            }

        }
        static void Main(string[] args)
        {
            Console.WriteLine("开始搬3个盘子..");
            Hanoi(3, 'A', 'B', 'C');
            Console.WriteLine("搬迁结速；一共进行了{0}次的搬迁。", count);
            Console.Read();
        }
    }
}
