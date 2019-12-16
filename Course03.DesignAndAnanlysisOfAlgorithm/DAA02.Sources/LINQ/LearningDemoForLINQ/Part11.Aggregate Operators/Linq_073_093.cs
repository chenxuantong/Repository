using LearningDemoForLINQ.Entities;
using LearningDemoForLINQ.Ultilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningDemoForLINQ.Part11.Aggregate_Operators
{
    /// <summary>
    /// 用于演示数据集合元素累计（聚合）相关的处理操作的应用范例
    /// </summary>
    public class Linq_073_093
    {
        /// <summary>
        /// 使用 Count 获取一个整型数集合中不重复的元素的数量
        /// </summary>
        public void Linq073()
        {
            int[] primeFactorsOf300 = { 2, 2, 3, 5, 5 };

            int uniqueFactors = primeFactorsOf300.Distinct().Count();

            Console.WriteLine("共有 {0} 个不重复的数据元素：", uniqueFactors);
        }

        /// <summary>
        /// 使用 Count 返回一个整型数集合中全部的奇数的数量。
        /// </summary>
        public void Linq074()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            int oddNumbers = numbers.Count(n => n % 2 == 1);

            Console.WriteLine("集合中全部的奇数的数量是： {0} ", oddNumbers);
        }

        /// <summary>
        /// 使用 Count 从客户数据集合中返回一个集合，其中的数据元素为：客户ID，订单数量
        /// </summary>
        public void Linq076()
        {
            List<Customer> customers = DataRepository.GetCustomers();

            var orderCounts =
                from cust in customers
                select new { cust.CustomerID, OrderCount = cust.Orders.Count() };

            ObjectDumper.Write(orderCounts);
        }

        /// <summary>
        /// 使用 Count 从产品数据集合中，返回产品分类和对应的产品数量
        /// </summary>
        public void Linq077()
        {
            List<Product> products = DataRepository.GetProducts();

            var categoryCounts =
                from prod in products
                group prod by prod.Category into prodGroup
                select new { Category = prodGroup.Key, ProductCount = prodGroup.Count() };

            ObjectDumper.Write(categoryCounts);
        }

        /// <summary>
        /// 使用 Sum 对一个整数集合的全部元素求和
        /// </summary>
        public void Linq078()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            double numSum = numbers.Sum();

            Console.WriteLine("集合元素的求和为： {0}.", numSum);
        }

        /// <summary>
        /// 使用 Sum 对一个字符串集合的所有元素的字符数量求和
        /// </summary>
        public void Linq079()
        {
            string[] words = { "cherry", "apple", "blueberry" };

            double totalChars = words.Sum(w => w.Length);

            Console.WriteLine("words字符串数组的全部字符数量为：", totalChars);
        }

        /// <summary>
        /// 使用 Sum 获取每个产品分类的库存数量
        /// </summary>
        public void Linq080()
        {
            List<Product> products = DataRepository.GetProducts();

            var categories =
                from prod in products
                group prod by prod.Category into prodGroup
                select new { Category = prodGroup.Key, TotalUnitsInStock = prodGroup.Sum(p => p.UnitsInStock) };

            ObjectDumper.Write(categories);
        }

        /// <summary>
        /// 使用 Min 获取一个整数集合的最小值
        /// </summary>
        public void Linq081()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            int minNum = numbers.Min();

            Console.WriteLine("最小值是 {0}.", minNum);
        }

        /// <summary>
        /// 使用 Min 获取一个字符串数组中字符数量最少的元素
        /// </summary>
        public void Linq082()
        {
            string[] words = { "cherry", "apple", "blueberry" };

            int shortestWord = words.Min(w => w.Length);
            var targetString = words.Where(x => x.Length == words.Min(w => w.Length)).FirstOrDefault();
            Console.WriteLine("字符数量最少的元素是： {0} 。", shortestWord);
        }

        /// <summary>
        /// 使用 Min 获取每个产品分类中最便宜的产品单价
        /// </summary>
        public void Linq083()
        {
            List<Product> products = DataRepository.GetProducts();

            var categories =
                from prod in products
                group prod by prod.Category into prodGroup
                select new { Category = prodGroup.Key, CheapestPrice = prodGroup.Min(p => p.UnitPrice) };

            ObjectDumper.Write(categories);
        }

        /// <summary>
        /// 使用 Min 获取获取每个产品分类中最便宜的产品
        /// </summary>
        public void Linq084()
        {
            List<Product> products = DataRepository.GetProducts();

            var categories =
                from prod in products
                group prod by prod.Category into prodGroup
                let minPrice = prodGroup.Min(p => p.UnitPrice)
                select new { Category = prodGroup.Key, CheapestProducts = prodGroup.Where(p => p.UnitPrice == minPrice) };

            ObjectDumper.Write(categories, 1);
        }

        /// <summary>
        /// 使用 Max 获取一个整型数集合的最大值
        /// </summary>
        public void Linq085()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            int maxNum = numbers.Max();

            Console.WriteLine("整型数集合的最大值： {0}.", maxNum);
        }

        /// <summary>
        /// 使用 Max 获取获取一个字符串数组中字符数量最多的元素
        /// </summary>
        public void Linq086()
        {
            string[] words = { "cherry", "apple", "blueberry" };

            int longestLength = words.Max(w => w.Length);

            Console.WriteLine("字符数量最少的元素是： {0} 。", longestLength);
        }

        /// <summary>
        /// 使用 Max 获取每个产品分类中最贵的产品单价
        /// </summary>
        public void Linq087()
        {
            List<Product> products = DataRepository.GetProducts();

            var categories =
                from prod in products
                group prod by prod.Category into prodGroup
                select new { Category = prodGroup.Key, MostExpensivePrice = prodGroup.Max(p => p.UnitPrice) };

            ObjectDumper.Write(categories);
        }

        /// <summary>
        /// 使用 Max 获取获取每个产品分类中最贵的产品
        /// </summary>
        public void Linq088()
        {
            List<Product> products = DataRepository.GetProducts();

            var categories =
                from prod in products
                group prod by prod.Category into prodGroup
                let maxPrice = prodGroup.Max(p => p.UnitPrice)
                select new { Category = prodGroup.Key, MostExpensiveProducts = prodGroup.Where(p => p.UnitPrice == maxPrice) };

            ObjectDumper.Write(categories, 1);
        }

        /// <summary>
        /// 使用 Average 获取整型数集合中所有元素的平均值
        /// </summary>
        public void Linq089()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            double averageNum = numbers.Average();

            Console.WriteLine("集合中所有元素的平均值是： {0}.", averageNum);
        }

        /// <summary>
        /// 使用 Average 获取一个字符串数组中所有元素的字符数平均值
        /// </summary>
        [Description("This sample uses Average to get the average length of the words in the array.")]
        public void Linq090()
        {
            string[] words = { "cherry", "apple", "blueberry" };

            double averageLength = words.Average(w => w.Length);

            Console.WriteLine("字符数平均值是： {0} 。", averageLength);
        }

        /// <summary>
        /// 使用 Average 计算各个产品分类的产品的平均价格
        /// </summary>
        public void Linq091()
        {
            List<Product> products = DataRepository.GetProducts();

            var categories =
                from prod in products
                group prod by prod.Category into prodGroup
                select new { Category = prodGroup.Key, AveragePrice = prodGroup.Average(p => p.UnitPrice) };

            ObjectDumper.Write(categories);
        }

        /// <summary>
        /// 使用 Aggregate 一个数组元素的累计乘法的结果
        /// 这个语法可以做一些复杂的聚合运算，例如累计求和，累计求乘积。
        /// 它接受2个参数，一般第一个参数是称为累积数（默认情况下等于第一个值），而第二个代表了下一个值。
        /// 第一次计算之后，计算的结果会替换掉第一个参数，继续参与下一次计算。
        /// </summary>
        public void Linq092()
        {
            double[] doubles = { 1.0, 2.0, 1.0, 4.0, 2.0 };

            double product = doubles.Aggregate((runningProduct, nextFactor) => runningProduct * nextFactor);
            double product01 = doubles.Aggregate((x, y) => x * y);

            Console.WriteLine("所有数据的积是: {0}", product);
        }

        /// <summary>
        /// 使用 Aggregate 对初始额度为 100 的某银行卡，累计扣减消费数，在余额不能低于 0 的条件下，计算出最后的额度。
        /// </summary>
        public void Linq093()
        {
            double startBalance = 100.0;    // 初始额度

            int[] attemptedWithdrawals = { 20, 10, 40, 50, 10, 70, 30 };

            double endBalance = attemptedWithdrawals.Aggregate(startBalance,
                (balance, nextWithdrawal) =>
                ((nextWithdrawal <= balance) ? (balance - nextWithdrawal) : balance));

            Console.WriteLine("最后的信用额度是： {0}", endBalance);
        }

    }
}
