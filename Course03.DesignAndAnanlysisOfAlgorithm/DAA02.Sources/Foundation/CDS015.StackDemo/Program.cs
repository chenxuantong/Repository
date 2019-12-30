using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDS015.StackDemo
{
    /// <summary>
    /// 栈的应用
    /// </summary>
    class Program
    {
        static void Main()
        {
            Stack<string> numbers = new Stack<string>();
            numbers.Push("壹");
            numbers.Push("贰");
            numbers.Push("叁");
            numbers.Push("肆");
            numbers.Push("伍");

            // 遍历
            foreach (string number in numbers)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine("\n出栈： '{0}'", numbers.Pop());
            Console.WriteLine("新的栈顶: {0}",numbers.Peek());
            Console.WriteLine("出栈： '{0}'", numbers.Pop());

            // 使用 numbers 构造第二个栈实例（拷贝）
            var temp = numbers.ToArray();
            var stack2 = new Stack<string>(numbers.ToArray());
            Console.WriteLine("\n第一个栈的内容拷贝：");
            foreach (string number in stack2)
            {
                Console.WriteLine(number);
            }

            // 根据 numbers 的数量*2 创建一个数组，并将 numbers 拷贝到数组 array2 中
            var array2 = new string[numbers.Count * 2];
            numbers.CopyTo(array2, numbers.Count);

            // 使用 array2 来创建一个栈
            var stack3 = new Stack<string>(array2);
            Console.WriteLine("\n第二个栈的内容:");
            foreach (string number in stack3)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine("\nstack2.包含(\"肆\") = {0}", stack2.Contains("肆"));

            Console.WriteLine("\nstack2.Clear()");
            stack2.Clear();
            Console.WriteLine("\nstack2.Count = {0}", stack2.Count);

            Console.ReadKey();
        }
    }
}
