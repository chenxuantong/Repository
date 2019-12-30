using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDS007.IDictionaryWithGenericsDemo
{
    class Program
    {
        static void Main()
        {
            // 直接使用 IDictionary 泛型接口来做一个字符串字典，key 也用字符串表示
            IDictionary<string, string> openWith = new Dictionary<string, string>();

            // 添加字典元素，注意：key不能重复，value是可以重复的。 
            openWith.Add("txt", "notepad.exe");
            openWith.Add("bmp", "paint.exe");
            openWith.Add("dib", "paint.exe");
            openWith.Add("rtf", "wordpad.exe");

            // 添加一个 key 重复的元素
            try
            {
                openWith.Add("txt", "winword.exe");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("键 = \"txt\" 的元素已经存在。");
            }
            Console.WriteLine("--------------------------------------------------------------------------");

            // 直接通过 key 名称来获取 value。 
            Console.WriteLine("键 = \"rtf\", 值 = {0}.", openWith["rtf"]);
            Console.WriteLine("--------------------------------------------------------------------------");

            // 修改 key 对应的 value
            openWith["rtf"] = "winword.exe";
            Console.WriteLine("键 = \"rtf\", 值 = {0}.", openWith["rtf"]);
            Console.WriteLine("--------------------------------------------------------------------------");

            // 如果 key 不存在，直接添加到字典中。
            openWith["doc"] = "winword.exe";
            // 请求一个不存在的 key ，抛出异常
            try
            {
                Console.WriteLine("键 = \"tif\", 值 = {0}.",
                    openWith["tif"]);
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("键 = \"tif\" 的元素不存在。");
            }
            Console.WriteLine("--------------------------------------------------------------------------");

            // 可以使用 TryGetValue 方法来获取 value 是否成功的方式来判断是否有某个 key
            var value = "";
            if (openWith.TryGetValue("tif", out value))
            {
                Console.WriteLine("键000 = \"tif\", 值 = {0}.", value);
            }
            else
            {
                Console.WriteLine("键000 = \"tif\" 不存在。");
            }
            Console.WriteLine("--------------------------------------------------------------------------");

            // 可以使用 ContainsKey 判断字典中是否存在响应的 key，以便判断是否执行插入操作。
            if (!openWith.ContainsKey("ht"))
            {
                openWith.Add("ht", "hypertrm.exe");
                Console.WriteLine("为 键 = \"ht\": 添加的值是：{0}", openWith["ht"]);
            }
            Console.WriteLine("--------------------------------------------------------------------------");

            // 使用 foreach 遍历枚举子时，返回的元素是一个键值对
            Console.WriteLine();
            foreach (KeyValuePair<string, string> kvp in openWith)
            {
                Console.WriteLine("键 = {0}, 值 = {1}", kvp.Key, kvp.Value);
            }
            Console.WriteLine("--------------------------------------------------------------------------");

            // 希望单独获取字典中的值，可使用 Values 属性来获取。
            ICollection<string> icoll = openWith.Values;
            Console.WriteLine();
            foreach (string s in icoll)
            {
                Console.WriteLine("值 = {0}", s);
            }
            Console.WriteLine("--------------------------------------------------------------------------");

            // 希望单独获取字典中的键，可使用 Keys 属性来获取。
            icoll = openWith.Keys;
            Console.WriteLine();
            foreach (string s in icoll)
            {
                Console.WriteLine("键 = {0}", s);
            }
            Console.WriteLine("--------------------------------------------------------------------------");

            // 移除一个字典元素
            Console.WriteLine("移除 (\"doc\")");
            openWith.Remove("doc");
            if (!openWith.ContainsKey("doc"))
            {
                Console.WriteLine("键为 \"doc\" 不存在。");
            }

            Console.ReadKey();
        }
    }
}
