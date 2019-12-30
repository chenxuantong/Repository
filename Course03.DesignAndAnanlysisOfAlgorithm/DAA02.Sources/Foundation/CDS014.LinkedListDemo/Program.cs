using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDS014.LinkedListDemo
{
    /// <summary>
    /// 链表的应用说明
    /// </summary>
    class Program
    {
        static void Main()
        {
            // 创建一个链表
            string[] words = { "那只", "狐狸", "跳", "过", "那只", "狗" };
            var sentence = new LinkedList<string>(words);

            Display(sentence, "链表的值：");
            Console.WriteLine("sentence.Contains(\"跳\") = {0}", sentence.Contains("跳"));

            // 添加‘今天’到链表的头
            sentence.AddFirst("今天");
            Display(sentence, "Test 1: 添加‘今天’到链表的头：");

            // 将链表的第一个节点挪到末尾节点
            LinkedListNode<string> mark1 = sentence.First;
            sentence.RemoveFirst();
            sentence.AddLast(mark1);
            Display(sentence, "Test 2: 将链表的第一个节点挪到最后：");

            // 将链表的最后一个节点变成‘昨天’
            sentence.RemoveLast();
            sentence.AddLast("昨天");
            Display(sentence, "Test 3: 将链表的最后一个节点变成‘昨天’：");

            // 将链表的最后一个节点挪到起始节点
            mark1 = sentence.Last;
            sentence.RemoveLast();
            sentence.AddFirst(mark1);
            Display(sentence, "Test 4: 将链表的最后一个节点挪到起始节点：");


            // 使用双括号标识出最后一个‘那只’
            sentence.RemoveFirst();
            LinkedListNode<string> current = sentence.FindLast("那只");
            IndicateNode(current, "Test 5: 使用双括号标识出最后一个‘那只’:");

            // 在‘那只’节点后面田间‘又老’，‘又懒’两个节点 ：注意 current 在上面定位的
            sentence.AddAfter(current, "又老");
            sentence.AddAfter(current, "又懒");
            IndicateNode(current, "Test 6: 在‘那只’后面田间‘又老’，‘又懒’:");

            // 标识出‘狐狸’几点
            current = sentence.Find("狐狸");
            IndicateNode(current, "Test 7: 标识出‘狐狸’:");

            // 在‘狐狸’节点之前添加‘敏捷’，‘棕色’两个节点
            sentence.AddBefore(current, "敏捷");
            sentence.AddBefore(current, "棕色");
            IndicateNode(current, "Test 8: 在‘狐狸’节点之前添加‘敏捷’，‘棕色’两个节点:");

            // 在当前的‘狐狸’节点，提取前一个节点，标识‘狗’节点
            mark1 = current;
            LinkedListNode<string> mark2 = current.Previous;
            current = sentence.Find("狗");
            IndicateNode(current, "Test 9: 在当前的‘狐狸’节点，提取前一个节点，标识‘狗’节点:");

            // 相同的节点不能重复添加
            Console.WriteLine("Test 10: 向链表中添加相同节点的异常信息:");
            try
            {
                sentence.AddBefore(current, mark1);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("异常信息: {0}", ex.Message);
            }
            Console.WriteLine();

            // 移除 mark1，添加到 current 之前
            sentence.Remove(mark1);
            sentence.AddBefore(current, mark1);
            IndicateNode(current, "Test 11: 移动 (狐狸) 到 (狗) 前面:");

            // 移除当前的节点‘狗’
            sentence.Remove(current);
            IndicateNode(current, "Test 12:  移除当前的节点‘狗’然后试图标识它出来:");

            // 在结点 mark2 后面添加 current 节点
            sentence.AddAfter(mark2, current);
            IndicateNode(current, "Test 13: 在结点 mark2 (棕色) 添加 current 节点:");

            // 通过指定的值移除相应的节点
            sentence.Remove("又老");
            Display(sentence, "Test 14: 通过指定的值移除相应的节点（又老）:");

            // 移除最后一个节点，将链表转型为 ICollection，使用 Add 方法在集合中元素的最后添加一个元素（不是节点）。
            sentence.RemoveLast();
            ICollection<string> icoll = sentence;
            icoll.Add("犀牛");
            Display(sentence, "Test 15: 移除最后一个节点，将链表转型为 ICollection，使用 Add 方法添加一个元素:");

            Console.WriteLine("Test 16: 将 sentence 拷贝到一个数组:");
            string[] sArray = new string[sentence.Count];
            sentence.CopyTo(sArray, 0);

            foreach (string s in sArray)
            {
                Console.WriteLine(s);
            }
            // 清除链表的全部节点
            sentence.Clear();
            Console.WriteLine();
            Console.WriteLine("Test 17:清除的链表，包含有 '跳'的节点 = {0}", sentence.Contains("跳"));
            Console.ReadLine();
        }

        private static void Display(LinkedList<string> words, string test)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(test);
            Console.ForegroundColor = ConsoleColor.White;
            foreach (string word in words)
            {
                Console.Write(word + " ");
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        private static void IndicateNode(LinkedListNode<string> node, string test)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(test);
            Console.ForegroundColor = ConsoleColor.White;
            if (node.List == null)
            {
                Console.WriteLine("节点 '{0}' 不在链表中。\n",
                    node.Value);
                return;
            }

            StringBuilder result = new StringBuilder("(" + node.Value + ")");
            LinkedListNode<string> nodeP = node.Previous;

            while (nodeP != null)
            {
                result.Insert(0, nodeP.Value + " ");
                nodeP = nodeP.Previous;
            }

            node = node.Next;
            while (node != null)
            {
                result.Append(" " + node.Value);
                node = node.Next;
            }

            Console.WriteLine(result);
            Console.WriteLine();
        }
    }
}
