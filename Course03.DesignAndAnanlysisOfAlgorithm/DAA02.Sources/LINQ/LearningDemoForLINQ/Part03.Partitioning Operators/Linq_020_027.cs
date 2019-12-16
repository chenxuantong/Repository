using LearningDemoForLINQ.Entities;
using LearningDemoForLINQ.Ultilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningDemoForLINQ.Part03.Partitioning_Operators
{
    public class Linq_020_027
    {
        /// <summary>
        /// 使用 Take 从数据集合元素中取出前面3个元素
        /// </summary>
        public void Linq020()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var first3Numbers = numbers.Take(3);

            Console.WriteLine("前面三个元素：");
            foreach (var n in first3Numbers)
            {
                Console.WriteLine(n);
            }
        }

        /// <summary>
        /// 使用 Take 从所有属于华盛顿的客户的全部订单的前面3份订单
        /// </summary>
        public void Linq021()
        {
            List<Customer> customers = DataRepository.GetCustomers();

            var first3WAOrders = (
                from cust in customers
                from order in cust.Orders
                where cust.Region == "WA"
                select new { cust.CustomerID, order.OrderID, order.OrderDate })
                .Take(3);

            Console.WriteLine("华盛顿的客户的全部订单的前面3份订单:");
            foreach (var order in first3WAOrders)
            {
                ObjectDumper.Write(order);
            }
        }

        /// <summary>
        /// 使用 Skip 从数据集合元素中取出忽略前面4个元素的全部剩余元素
        /// </summary>
        public void Linq022()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var allButFirst4Numbers = numbers.Skip(4);

            Console.WriteLine("除了前面4个元素之外的全部数据:");
            foreach (var n in allButFirst4Numbers)
            {
                Console.WriteLine(n);
            }
        }

        /// <summary>
        /// 使用 Skip 从所有属于华盛顿的客户的全部订单中，取出忽略前面两份订单的全部剩余订单
        /// </summary>
        public void Linq023()
        {
            List<Customer> customers = DataRepository.GetCustomers();

            var waOrders =
                from cust in customers
                from order in cust.Orders
                where cust.Region == "WA"
                select new { cust.CustomerID, order.OrderID, order.OrderDate };

            var allButFirst2Orders = waOrders.Skip(2);

            Console.WriteLine("所有属于华盛顿的客户的全部订单中，取出忽略前面两份订单的全部剩余订单:");
            foreach (var order in allButFirst2Orders)
            {
                ObjectDumper.Write(order);
            }
        }

        /// <summary>
        /// 使用 TakeWhile 从数据集合元素中从头开始逐个选取数据，直到满足不 小于 6 的元素结束。
        /// </summary>
        public void Linq024()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var firstNumbersLessThan6 = numbers.TakeWhile(n => n < 6);  

            Console.WriteLine("数据集合元素中从头开始逐个选取数据，直到遇到 > 6 的元素为止:");
            foreach (var num in firstNumbersLessThan6)
            {
                Console.WriteLine(num);
            }
        }

        /// <summary>
        /// 使用 TakeWhile 从数据集合元素中从头开始逐个选取数据，直到元素的索引不小于等于它的值为止。
        /// </summary>
        public void Linq025()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var firstSmallNumbers = numbers.TakeWhile((n, index) => n >= index);

            Console.WriteLine("从数据集合元素中从头开始逐个选取数据，直到元素的索引不小于等于它的值为止：");
            foreach (var n in firstSmallNumbers)
            {
                Console.WriteLine(n);
            }
        }

        /// <summary>
        /// 使用 SkipWhile 从数据集合元素中从头开始逐个选取数据，忽略哪些第一个可以被3整除的元素之前的全部元素。
        /// </summary>
        public void Linq026()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            // 在 Lambda 表达式中，n 是一个输入参数，用来标识集合中的每个顺序元素，
            // 其类型则由数据集合元素的类型自动推断。
            var allButFirst3Numbers = numbers.SkipWhile(n => n % 3 != 0);

            Console.WriteLine("第一个可以被3整除的元素之后的全部元素。");
            foreach (var n in allButFirst3Numbers)
            {
                Console.WriteLine(n);
            }
        }

        /// <summary>
        /// 使用 SkipWhile 从数据集合元素中从头开始逐个选取数据，忽略哪些直到发现索引值小于元素值的元素。
        /// </summary>
        public void Linq027()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var laterNumbers = numbers.SkipWhile((n, index) => n >= index);

            Console.WriteLine("从第一个索引值小于元素值之后的全部元素：");
            foreach (var n in laterNumbers)
            {
                Console.WriteLine(n);
            }
        }

    }
}
