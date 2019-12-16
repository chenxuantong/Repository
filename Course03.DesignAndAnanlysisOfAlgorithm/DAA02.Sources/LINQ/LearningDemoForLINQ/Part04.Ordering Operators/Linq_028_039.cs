using LearningDemoForLINQ.Entities;
using LearningDemoForLINQ.Ultilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningDemoForLINQ.Part04.Ordering_Operators
{
    public class Linq_028_039
    {
        /// <summary>
        /// 使用 OrderBy 对字符串数组 words 按照字母顺序进行排序。
        /// </summary>
        public void Linq028()
        {
            string[] words = { "cherry", "apple", "blueberry" };

            var sortedWords =
                from word in words
                orderby word
                select word;

            Console.WriteLine("排序后的字符串数组元素：");
            foreach (var w in sortedWords)
            {
                Console.WriteLine(w);
            }
        }

        /// <summary>
        /// 使用 OrderBy 对字符串数组 words 按照字符串长度进行排序。
        /// </summary>
        public void Linq029()
        {
            string[] words = { "cherry", "apple", "blueberry" };

            var sortedWords =
                from word in words
                orderby word.Length
                select word;

            Console.WriteLine("按照长度排序的结果:");
            foreach (var w in sortedWords)
            {
                Console.WriteLine(w);
            }
        }

        /// <summary>
        /// 使用 OrderBy 对商品集合元素的 Name 属性进行排序，还可以添加 descending 反序条件
        /// </summary>
        public void Linq030()
        {
            List<Product> products = DataRepository.GetProducts();

            var sortedProducts =
                from prod in products
                orderby prod.ProductName // descending  // 反序
                select prod;

            ObjectDumper.Write(sortedProducts);
        }

        /// <summary>
        /// 使用 OrderBy 以及一个自定义的比较运算符，按照大小写敏感的次序对字符串数组进行排序
        /// </summary>
        public void Linq031()
        {
            string[] words = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

            var sortedWords = words.OrderBy(a => a, new CaseInsensitiveComparer());

            ObjectDumper.Write(sortedWords);
        }

        /// <summary>
        /// 使用 OrderBy 和 descending 对数值数组进行排序（高到低）
        /// </summary>
        public void Linq032()
        {
            double[] doubles = { 1.7, 2.3, 1.9, 4.1, 2.9 };

            var sortedDoubles =
                from d in doubles
                orderby d descending
                select d;

            Console.WriteLine("从高到低的数据列表:");
            foreach (var d in sortedDoubles)
            {
                Console.WriteLine(d);
            }
        }

        /// <summary>
        /// 使用 orderby 和 descending 将商品按照库存量从高到低排序
        /// </summary>
        public void Linq033()
        {
            List<Product> products = DataRepository.GetProducts();

            var sortedProducts =
                from prod in products
                orderby prod.UnitsInStock descending
                select prod;

            ObjectDumper.Write(sortedProducts);
        }

        /// <summary>
        /// 使用 OrderByDescending 的方法以及自定义的比较运算符，对一个字符串数组进行排序
        /// </summary>
        public void Linq034()
        {
            string[] words = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

            var sortedWords = words.OrderByDescending(a => a, new CaseInsensitiveComparer());

            ObjectDumper.Write(sortedWords);
        }

        /// <summary>
        /// 使用混合 orderby 对一组数字字符串进行排序：先按照长度，而后按照字母顺序排序。
        /// </summary>
        public void Linq035()
        {
            string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var sortedDigits =
                from digit in digits
                orderby digit.Length, digit
                select digit;

            Console.WriteLine("先按照长度，而后按照字母顺序排序:");
            foreach (var d in sortedDigits)
            {
                Console.WriteLine(d);
            }
        }

        /// <summary>
        /// 第一个查询使用 OrderBy 先按照字符串长度排序，然后使用 ThenBy 再次按照自定的比较运算符排序
        /// 第二个查询其实就是前一种的另外一种写法
        /// </summary>
        public void Linq036()
        {
            string[] words = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

            var sortedWords =
                words.OrderBy(a => a.Length)
                     .ThenBy(a => a, new CaseInsensitiveComparer());

            var sortedWords2 =
                from word in words
                orderby word.Length
                select word;

            var sortedWords3 = sortedWords2.ThenBy(a => a, new CaseInsensitiveComparer());

            ObjectDumper.Write(sortedWords);

            ObjectDumper.Write(sortedWords3);
        }

        /// <summary>
        /// 使用混合 orderby 查询产品列表，先按照分类，然后按照单价排序列出来
        /// </summary>
        public void Linq037()
        {
            List<Product> products = DataRepository.GetProducts();

            var sortedProducts =
                from prod in products
                orderby prod.Category, prod.UnitPrice descending
                select prod;

            ObjectDumper.Write(sortedProducts);
        }

        /// <summary>
        /// 第一个查询使用 OrderBy 先按照字符串长度排序，然后使用 ThenByDescending 再次按照自定的比较运算符排序
        /// </summary>
        public void Linq038()
        {
            string[] words = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

            var sortedWords =
                words.OrderBy(a => a.Length)
                     .ThenByDescending(a => a, new CaseInsensitiveComparer());

            ObjectDumper.Write(sortedWords);
        }

        /// <summary>
        /// 先查询出字符串中，第二个字符是 i 的元素，然后使用 Reverse 对结果集合进行反转操作。
        /// </summary>
        public void Linq039()
        {
            string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var reversedIDigits = (
                from digit in digits
                where digit[1] == 'i'
                select digit)
                .Reverse();

            Console.WriteLine("第二个字符为 'i'的，反转后的查询结构：");
            foreach (var d in reversedIDigits)
            {
                Console.WriteLine(d);
            }
        }

    }
}
