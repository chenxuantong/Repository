using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningDemoForLINQ.Part07.Conversion_Operators
{
    /// <summary>
    /// 用于演示转换操作相关的运算符的使用
    /// </summary>
    class Linq_054_057
    {
        /// <summary>
        /// 使用 ToArray 将一个集合转换为数组
        /// </summary>
        public void Linq054()
        {
            double[] doubles = { 1.7, 2.3, 1.9, 4.1, 2.9 };

            var sortedDoubles =
                from d in doubles
                orderby d descending
                select d;
            var doublesArray = sortedDoubles.ToArray();

            Console.WriteLine("从高到低排序的结果：");
            for (int d = 0; d < doublesArray.Length; d += 2)
            {
                Console.WriteLine(doublesArray[d]);
            }
        }

        /// <summary>
        /// 使用 ToList 将一个集合转换为 List<T>
        /// </summary>
        public void Linq055()
        {
            string[] words = { "cherry", "apple", "blueberry" };

            var sortedWords =
                from w in words
                orderby w
                select w;
            var wordList = sortedWords.ToList();

            Console.WriteLine("排序后的单词是：");
            foreach (var w in wordList)
            {
                Console.WriteLine(w);
            }
        }

        /// <summary>
        /// 使用 ToDictionary 将一个数据集合转为字典集合
        /// </summary>
        public void Linq056()
        {
            var scoreRecords = new[] 
            {
                new {Name = "Alice", Score = 50},
                new {Name = "Bob"  , Score = 40},
                new {Name = "Cathy", Score = 45}
            };

            var scoreRecordsDict = scoreRecords.ToDictionary(sr => sr.Name);

            Console.WriteLine("Bob的分数: {0}", scoreRecordsDict["Bob"]);
        }

        /// <summary>
        /// 使用 OfType 返回数据集合元素中制定的类型
        /// </summary>
        public void Linq057()
        {
            object[] numbers = { null, 1.0, "two", 3, "four", 5, "six", 7.0 };

            var doubles = numbers.OfType<double>();

            Console.WriteLine("使用 double 方式存贮的数据是：");
            foreach (var d in doubles)
            {
                Console.WriteLine(d);
            }
        }
    }
}
