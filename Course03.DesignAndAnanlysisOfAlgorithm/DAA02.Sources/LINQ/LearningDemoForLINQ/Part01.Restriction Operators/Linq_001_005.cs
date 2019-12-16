using LearningDemoForLINQ.Entities;
using LearningDemoForLINQ.Ultilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningDemoForLINQ.Part01.Restriction_Operators
{
    /// <summary>
    /// 用于演示说明限制性（主要通过 where）访问数据集合的常规范例
    /// </summary>
    public class Linq_001_005
    {
        /// <summary>
        /// 在数据集合：int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };中查询小于 5 的元素
        /// </summary>
        public void Linq001()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var lowNums =
                from num in numbers
                where num < 5
                select num;

            Console.WriteLine("Numbers < 5:");
            foreach (var x in lowNums)
            {
                Console.WriteLine(x);
            }
        }

        /// <summary>
        /// 在商品的数据集合中，查询库存数量为零的商品：
        /// prod.UnitsInStock == 0
        /// </summary>
        public void Linq002()
        {
            List<Product> products = DataRepository.GetProducts();

            var soldOutProducts =
                from prod in products
                where prod.UnitsInStock == 0
                select prod;

            Console.WriteLine("已经售空的商品：");
            foreach (var product in soldOutProducts)
            {
                Console.WriteLine("{0} 已经售空!", product.ProductName);
            }
        }

        /// <summary>
        /// 在商品的数据集合中，查询 库存数量>0 并且单价>3.00的商品：
        /// where prod.UnitsInStock > 0 && prod.UnitPrice > 3.00M
        /// </summary>
        [Description("This sample uses the where clause to find all products that are in stock and " +
         "cost more than 3.00 per unit.")]
        public void Linq003()
        {
            List<Product> products = DataRepository.GetProducts();

            var expensiveInStockProducts =
                from prod in products
                where prod.UnitsInStock > 0 && prod.UnitPrice > 3.00M
                select prod;

            Console.WriteLine("库存商品中，单价大于 3.00 的商品：");
            foreach (var product in expensiveInStockProducts)
            {
                Console.WriteLine("{0} 有库存，单价大于 3.00。", product.ProductName);
            }
        }

        /// <summary>
        /// 在客户的数据集合中，查询地区是 WA 的客户，然后再查询每个满足条件客户的所有的订单
        /// </summary>
        public void Linq004()
        {
            List<Customer> customers = DataRepository.GetCustomers();
            // 查询客户区域是WA的客户
            var waCustomers =
                from cust in customers
                where cust.Region == "WA"
                select cust;
            
            Console.WriteLine("来自华盛顿的客户以及他们的订单：");
            foreach (var customer in waCustomers)      // 遍历查询结果的客户
            {
                Console.WriteLine("客户 {0}: {1}", customer.CustomerID, customer.CompanyName);
                foreach (var order in customer.Orders) // 遍历每个客户的全部订单
                {
                    Console.WriteLine("  订单 {0}: {1}", order.OrderID, order.OrderDate);
                }
            }
        }

        /// <summary>
        /// 对于数据集合：string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        /// 查询集合元素的：字符长度小于其索引值 的元素。
        /// </summary>
        public void Linq005()
        {
            string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var shortDigits = digits.Where((digit, x) => digit.Length < x);

            Console.WriteLine("Short digits:");
            foreach (var d in shortDigits)
            {
                Console.WriteLine("The word {0} is shorter than its value.", d);
            }
        }

    }

}
