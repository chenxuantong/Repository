using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningDemoForLINQ.Part09.Generation_Operators
{
    /// <summary>
    /// 与集合元素生成运算符相关的应用范例
    /// </summary>
    public class Linq_065_066
    {
        /// <summary>
        /// 本例使用 Range 生成 100 到 149 之间的数列，以便用来检查是奇数还是偶数
        /// </summary>
        public void Linq065()
        {
            var numbers =
                from n in Enumerable.Range(100, 50)
                select new { Number = n, OddEven = n % 2 == 1 ? "奇数" : "偶数" };

            foreach (var n in numbers)
            {
                Console.WriteLine("数字 {0} 是 {1}.", n.Number, n.OddEven);
            }
        }

        /// <summary>
        /// 使用 Repeat 产生 10 个 7 并返回一个数据集合
        /// </summary>
        public void Linq066()
        {
            var numbers = Enumerable.Repeat(7, 10);

            foreach (var n in numbers)
            {
                Console.WriteLine(n);
            }
        }
    }
}
