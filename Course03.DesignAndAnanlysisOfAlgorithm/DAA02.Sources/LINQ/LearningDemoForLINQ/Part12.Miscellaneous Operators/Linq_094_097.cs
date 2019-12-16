using LearningDemoForLINQ.Entities;
using LearningDemoForLINQ.Ultilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningDemoForLINQ.Part12.Miscellaneous_Operators
{
    /// <summary>
    /// 用于演示说明一些合成相关的方法
    /// </summary>
    public class Linq_094_097
    {
        /// <summary>
        /// 使用 Concat 将两个数组的元素逐个合成
        /// </summary>
        public void Linq094()
        {
            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            int[] numbersB = { 1, 3, 5, 7, 8 };

            var allNumbers = numbersA.Concat(numbersB);

            Console.WriteLine("合成后的数组元素:");
            foreach (var n in allNumbers)
            {
                Console.WriteLine(n);
            }
        }

        /// <summary>
        /// 使用 Concat 将客户和产品的名字合起来
        /// </summary>
        public void Linq095()
        {
            List<Customer> customers = DataRepository.GetCustomers();
            List<Product> products = DataRepository.GetProducts();

            var customerNames =
                from cust in customers
                select cust.CompanyName;
            var productNames =
                from prod in products
                select prod.ProductName;

            var allNames = customerNames.Concat(productNames);

            Console.WriteLine("客户和产品的名称：");
            foreach (var n in allNames)
            {
                Console.WriteLine(n);
            }
        }

        /// <summary>
        /// 使用 SequenceEqual 比较两个数据集合的所有元素是否完全相同
        /// </summary>
        public void Linq096()
        {
            var wordsA = new string[] { "cherry", "apple", "blueberry" };
            var wordsB = new string[] { "cherry", "apple", "blueberry" };

            bool match = wordsA.SequenceEqual(wordsB);

            Console.WriteLine("两个数据集合的所有元素是否完全相同： {0}", match);
        }

        /// <summary>
        /// 使用 SequenceEqual 比较两个数据集合的所有元素是否完全相同，并且次序也一样
        /// </summary>
        public void Linq097()
        {
            var wordsA = new string[] { "cherry", "apple", "blueberry" };
            var wordsB = new string[] { "apple", "blueberry", "cherry" };

            bool match = wordsA.SequenceEqual(wordsB);

            Console.WriteLine("T两个数据集合的所有元素以及排列次序是否完全相同： {0}", match);
        }
    }
}
