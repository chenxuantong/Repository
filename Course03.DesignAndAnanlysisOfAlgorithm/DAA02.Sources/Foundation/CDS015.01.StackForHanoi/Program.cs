using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDS015._01.StackForHanoi
{
    /// <summary>
    /// 使用栈来模拟 Hanoi 塔移动的过程
    /// </summary>
    class Program
    {
        static int diskAmount = 0;    // 碟子数量
        static int moveCount = 0;     // 移动次数

        static Stack<string> needleA;
        static Stack<string> needleB;
        static Stack<string> needleC;

        static void Main(string[] args)
        {
            diskAmount = 10;

            needleA = new Stack<string>();
            needleB = new Stack<string>();
            needleC = new Stack<string>();

            // 初始化，先把所有的碟子放在第一个塔
            for (int i = diskAmount; i > 0; i--)
            {
                needleA.Push(i.ToString());
            }

            Console.WriteLine();
            Console.WriteLine(" 碟子总数：{0}，起始状态", diskAmount);
            Console.WriteLine("================================================");
            Console.WriteLine(" A 塔状态：{0}", GetStackItemString(needleA));
            Console.WriteLine(" B 塔状态：{0}", GetStackItemString(needleB));
            Console.WriteLine(" C 塔状态：{0}", GetStackItemString(needleC));
            Console.WriteLine();

            MoveDiskInStacks(diskAmount, needleA, needleB, needleC);
            Console.ReadKey();

        }

        /// <summary>
        /// 移动碟子处理
        /// </summary>
        /// <param name="amount">待移动的数量</param>
        /// <param name="stack01">待移除的塔</param>
        /// <param name="stack02">过渡的塔</param>
        /// <param name="stack03">待移入的塔</param>
        static void MoveDiskInStacks(int amount, 
            Stack<string> stack01,Stack<string> stack02,Stack<string> stack03)
        {
            if (amount == 1)
            {
                ExchangeStackItem(stack01, stack03);
            }
            else
            {
                MoveDiskInStacks(amount - 1, stack01, stack03, stack02);
                ExchangeStackItem(stack01, stack03);
                MoveDiskInStacks(amount - 1, stack02, stack01, stack03);
            }
        }

        /// <summary>
        /// 两个栈的元素交换
        /// </summary>
        /// <param name="sourceStack">源栈</param>
        /// <param name="targetStack">目标栈</param>
        static void ExchangeStackItem(Stack<string> sourceStack,Stack<string> targetStack)
        {
            targetStack.Push(sourceStack.Pop());
            moveCount++;
            Console.WriteLine(" 这是第 {0} 步", moveCount);
            Console.WriteLine("================================================");
            Console.WriteLine(" A 塔状态：{0}", GetStackItemString(needleA));
            Console.WriteLine(" B 塔状态：{0}", GetStackItemString(needleB));
            Console.WriteLine(" C 塔状态：{0}", GetStackItemString(needleC));
            Console.WriteLine();
        }

        /// <summary>
        /// 打印栈内元素的名称
        /// </summary>
        /// <param name="stack"></param>
        /// <returns></returns>
        static string GetStackItemString(Stack<string> stack)
        {
            var itemsString = "";
            foreach (var item in stack.Reverse())
                itemsString = itemsString + item + ",";

            return itemsString;
        }
   }
}
