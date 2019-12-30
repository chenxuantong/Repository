using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDS016.QueueDemo
{
    /// <summary>
    /// 队列
    /// </summary>
    class Program
    {
        static void Main()
        {
            var numbers = new Queue<string>();
            numbers.Enqueue("壹");
            numbers.Enqueue("贰");
            numbers.Enqueue("叁");
            numbers.Enqueue("肆");
            numbers.Enqueue("伍");

            // 遍历
            foreach (string number in numbers)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine("\n出列 '{0}'", numbers.Dequeue());
            Console.WriteLine("新的队列头: {0}",numbers.Peek());
            Console.WriteLine("出列 '{0}'", numbers.Dequeue());

            // 使用 numbers 构造第二个队列实例（拷贝）
            var queueCopy = new Queue<string>(numbers.ToArray());
            Console.WriteLine("\n第一次拷贝的内容:");
            foreach (string number in queueCopy)
            {
                Console.WriteLine(number);
            }

            // 根据 numbers 的数量*2 创建一个数组，并将 numbers 拷贝到数组 array2 中
            var array2 = new string[numbers.Count * 2];
            numbers.CopyTo(array2, numbers.Count);

            // 使用 array2 来创建一个队列
            var queueCopy2 = new Queue<string>(array2);

            Console.WriteLine("\n第二个拷贝的内容:");
            foreach (string number in queueCopy2)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine("\nqueueCopy.Contains(\"肆\") = {0}", queueCopy.Contains("肆"));

            Console.WriteLine("\nqueueCopy.Clear()");
            queueCopy.Clear();
            Console.WriteLine("\nqueueCopy.Count = {0}", queueCopy.Count);

            Console.ReadKey();
        }
    }
}
