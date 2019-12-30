using CDS000.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDS012.HashTableDemo
{
    class Program
    {
        static void Main()
        {
            // var openWith = new Dictionary<string, string>();
            // 创建哈希表
            var openWith = new Hashtable();

            // 添加元素：键不能重复，值可以重复
            openWith.Add("txt", "notepad.exe");
            openWith.Add("bmp", "paint.exe");
            openWith.Add("dib", "paint.exe");
            openWith.Add("rtf", "wordpad.exe");

            // 对于已经存在的 键，如果添加相同的元素具有相同的键，将抛出异常 
            try
            {
                openWith.Add("txt", "winword.exe");
            }
            catch (Exception ex)
            {
                Console.WriteLine("键 = \"txt\" 的元素已经存在。");
                Console.WriteLine(ex.Message);
            }

            // 元素的属性就是其缺省的属性，可以直接用元素的 key 名访问元素的值 
            Console.WriteLine("键 = \"rtf\", 值 = {0}.", openWith["rtf"]);

            // 可以根据元素的 key 名，更新对应的值
            openWith["rtf"] = "winword.exe";
            Console.WriteLine("键 = \"rtf\", 值 = {0}.", openWith["rtf"]);

            // 如果 键 不存在，则直接创建一个键值对
            openWith["doc"] = "winword.exe";
            openWith["box"] = new Box(1,3,5);
            openWith["张廖玮"] = new Person {
                Name = "张廖玮",
                Province = "广西",
                City = "柳州",
                Sex = true,
                Birthday = DateTime.Parse("1985-08-08"),
                Email ="zhanglw@qq.com"
            };

            // 使用 ContainsKey 来判断是否执行添加键值对 
            if (!openWith.ContainsKey("ht"))
            {
                openWith.Add("ht", "hypertrm.exe");
                Console.WriteLine("针对键 = \"ht\" 添加了值: {0}。", openWith["ht"]);
            }

            // 遍历处理
            Console.WriteLine();
            foreach (DictionaryEntry de in openWith)
            {
                var result = de.Value;
                
                Console.WriteLine("键 = {0}, 值 = {1}", de.Key, de.Value);
            }

            // 使用 Values 属性，获取值的集合，返回的是一个 ICollection
            var valueColl = openWith.Values;

            // 直接遍历，注意输出结果
            Console.WriteLine();
            foreach (var s in valueColl)
            {
                Console.WriteLine("值 = {0}", s);
            }

            // 使用 Keys 属性，获取键的集合，返回的是一个 ICollection
            var keyColl = openWith.Keys;

            // 直接遍历
            Console.WriteLine();
            foreach (string s in keyColl)
            {
                Console.WriteLine("键 = {0}", s);
            }

            // 使用 Remove 移除一个键/值对
            Console.WriteLine("\n移除(\"doc\")");
            openWith.Remove("doc");

            if (!openWith.ContainsKey("doc"))
            {
                Console.WriteLine("键 \"doc\" 未找到。");
            }

            Console.ReadKey();
        }
    }
}
