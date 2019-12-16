using LearningDemoForLINQ.Entities;
using LearningDemoForLINQ.Ultilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningDemoForLINQ.Part06.Set_Operators
{
    /// <summary>
    /// 用于演示说明应用数据集合运算符的范例
    /// </summary>
    public class Linq_046_053
    {
        /// <summary>
        /// 使用 Distinct 清除数组 factorsOf300 中重复的元素。
        /// </summary>
        public void Linq046()
        {
            int[] factorsOf300 = { 2, 2, 3, 5, 5 };

            var uniqueFactors = factorsOf300.Distinct();

            Console.WriteLine("factorsOf300 中的不重复的元素：");
            foreach (var f in uniqueFactors)
            {
                Console.WriteLine(f);
            }
        }

        /// <summary>
        /// 这个例子使用 Distinct 获取唯一的产品分类的类别名称。
        /// </summary>
        public void Linq047()
        {
            List<Product> products = DataRepository.GetProducts();

            var categoryNames = (
                from prod in products
                select prod.Category)
                .Distinct();

            Console.WriteLine("产品分类名称：");
            foreach (var n in categoryNames)
            {
                Console.WriteLine(n);
            }
        }

        /// <summary>
        /// 应用 Uinon 运算符，在两个数据集合中，联合起来找出唯一存在的元素。
        /// </summary>
        public void Linq048()
        {
            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            int[] numbersB = { 1, 3, 5, 7, 8 };

            var uniqueNumbers = numbersA.Union(numbersB);

            Console.WriteLine("两个数组元素中唯一存在的元素:");
            foreach (var n in uniqueNumbers)
            {
                Console.WriteLine(n);
            }
        }

        /// <summary>
        /// 使用 Union 运算符，从产品和客户数据集合中，抽取名称首字母重新构建一个的序列，并且首字母唯一
        /// </summary>
        public void Linq049()
        {
            List<Product> products = DataRepository.GetProducts();
            List<Customer> customers = DataRepository.GetCustomers();

            var productFirstChars =
                from prod in products
                select prod.ProductName[0];
            var customerFirstChars =
                from cust in customers
                select cust.CompanyName[0];

            var uniqueFirstChars = productFirstChars.Union(customerFirstChars);

            Console.WriteLine("来自客户、产品名称的全部唯一的首字母：");
            foreach (var ch in uniqueFirstChars)
            {
                Console.WriteLine(ch);
            }
        }

        /// <summary>
        /// 应用 Intersect（交集） 创建一个新的包含两个数据集合公共的元素。
        /// </summary>
        public void Linq050()
        {
            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            int[] numbersB = { 1, 3, 5, 7, 8 };

            var commonNumbers = numbersA.Intersect(numbersB);

            Console.WriteLine("包含两个数据集合公共的元素：");
            foreach (var n in commonNumbers)
            {
                Console.WriteLine(n);
            }
        }

        /// <summary>
        /// 使用 Intersect 从客户、商品数据集合中元素的名称中的首字母，创建一个新的序列，包含两者公共的字母。
        /// </summary>
        public void Linq051()
        {
            List<Product> products = DataRepository.GetProducts();
            List<Customer> customers = DataRepository.GetCustomers();

            var productFirstChars =
                from prod in products
                select prod.ProductName[0];
            var customerFirstChars =
                from cust in customers
                select cust.CompanyName[0];

            var commonFirstChars = productFirstChars.Intersect(customerFirstChars);

            Console.WriteLine("包含两者 客户、商品 名称中公共的字母：");
            foreach (var ch in commonFirstChars)
            {
                Console.WriteLine(ch);
            }
        }

        /// <summary>
        /// 使用 Except 运算符，创建一个新的序列，在 A 集合中有，在 B 集合中没有
        /// </summary>
        public void Linq052()
        {
            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            int[] numbersB = { 1, 3, 5, 7, 8 };

            IEnumerable<int> aOnlyNumbers = numbersA.Except(numbersB);

            Console.WriteLine("在第一个集合中有，第二个集合中没有的元素：");
            foreach (var n in aOnlyNumbers)
            {
                Console.WriteLine(n);
            }
        }

        /// <summary>
        /// 使用 Except 从产品、客户数据集合中数据元素的首字母，创建一个新的序列，在产品集合中有，在 B 集合中没有
        /// </summary>
        public void Linq053()
        {
            List<Product> products = DataRepository.GetProducts();
            List<Customer> customers = DataRepository.GetCustomers();

            var productFirstChars =
                from prod in products
                select prod.ProductName[0];
            var customerFirstChars =
                from cust in customers
                select cust.CompanyName[0];

            var productOnlyFirstChars = productFirstChars.Except(customerFirstChars);

            Console.WriteLine("产品名称中的首字母，但没有包含在客户名称中的首字母：");
            foreach (var ch in productOnlyFirstChars)
            {
                Console.WriteLine(ch);
            }
        }
    }
}
