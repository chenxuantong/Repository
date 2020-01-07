using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 字典集合
{
    class Program
    {
        static void Main(string[] args)
        {
            IDictionary<string, string> students = new Dictionary<string, string>();
            students.Add("201801", "张三");
            students.Add("201802", "李四");
            Console.WriteLine("键 = \"201801\", 值 = {0}.", students["201801"]);
            Console.WriteLine("--------------------------------------------------------------------------");
            students["201801"] = "小李";
            Console.WriteLine("将张三改为, 值 = {0}.", students["201801"]);
            Console.WriteLine("--------------------------------------------------------------------------");
            students["201803"] = "王五";
            Console.WriteLine(" 新增学生对象:{0}.", students["201803"]);
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine("移除:李四");
            students.Remove("201802");
            if (!students.ContainsKey("201802"))
            {
                Console.WriteLine("键为201802不存在。");
            }
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine("什么样的数据元素的处理适合用 IDictionary 这一类的数据模型来表达?");
            Console.WriteLine("答：IDictionary<TKey, TValue> 接口是键/值对的泛型集合的基接口。每个元素都是一个存储在 KeyValuePair<TKey, TValue> 对象中的键/值对。每一对都必须有唯一的键。 实现在是否允许 key 为 null 方面有所不同。 此值可以为 null，并且不必是唯一的。 IDictionary<TKey, TValue> 接口允许对所包含的键和值进行枚举，但这并不意味着任何特定的排序顺序, IDictionary<TKey, TValue> 的每个元素都是一个键/值对");
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine("简要说明这个字典类可以有哪些用途？");
            Console.WriteLine("答：一个产品编号对应一个产品");
            Console.Read();
        }
    }
}
