using LearningDemoForLINQ.Entities;
using LearningDemoForLINQ.Ultilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningDemoForLINQ.Part15.Join_Operators
{
    /// <summary>
    /// 数据元素编联查询运算符
    /// </summary>
    public class Linq_102_107
    {
        /// <summary>
        /// 使用 join 的方法，将两个没有直接关系的数据集合结合起来，形成一个包含供应商、客户全部属性
        /// 以及满足两者之间的指定属性 Country 匹配的结果集
        /// </summary>
        public void Linq102()
        {

            List<Customer> customers = DataRepository.GetCustomers(); 
            List<Supplier> suppliers = DataRepository.GetSuppliers();

            var custSupJoin =
                from sup in suppliers
                join cust in customers on sup.Country equals cust.Country
                select new { Country = sup.Country, SupplierName = sup.SupplierName, CustomerName = cust.CompanyName };

            foreach (var item in custSupJoin)
            {
                Console.WriteLine("国家 = {0}, 供应商 = {1}, 客户 = {2}", item.Country, item.SupplierName, item.CustomerName);
            }
        }

        /// <summary>
        /// 使用 Join 构建一个有层次结构的序列
        /// </summary>
        public void Linq103()
        {


            List<Customer> customers = DataRepository.GetCustomers();
            List<Supplier> suppliers = DataRepository.GetSuppliers();

            var custSupQuery =
                from sup in suppliers
                join cust in customers on sup.Country equals cust.Country into cs
                select new { Key = sup.Country, Items = cs };


            foreach (var item in custSupQuery)
            {
                Console.WriteLine(item.Key + ":");
                foreach (var element in item.Items)
                {
                    Console.WriteLine("   " + element.CompanyName);
                }
            }
        }

        /// <summary>
        /// 使用 join 和一个外置的数据集合，再构建一个新的数据集合
        /// </summary>
        public void Linq104()
        {
            string[] categories = new string[]{
                "Beverages",        // 饮料
                "Condiments",       // 佐料
                "Vegetables",       // 蔬菜   
                "Dairy Products",   // 乳制品
                "Seafood"           // 海产品
            };

            List<Product> products = DataRepository.GetProducts();

            var prodByCategory =
                from cat in categories
                join prod in products on cat equals prod.Category into ps
                from p in ps
                select new { Category = cat, p.ProductName };

            foreach (var item in prodByCategory)
            {
                Console.WriteLine(item.ProductName + ": " + item.Category);
            }
        }

        /// <summary>
        /// 左编联的应用例子
        /// </summary>
        public void Linq105()
        {
            List<Customer> customers = DataRepository.GetCustomers();
            List<Supplier> suppliers = DataRepository.GetSuppliers();

            var supplierCusts =
                from sup in suppliers
                join cust in customers on sup.Country equals cust.Country into cs
                from c in cs.DefaultIfEmpty()  // DefaultIfEmpty 用于保存在左边的元素与右边的元素不同的情况下的缺省值。
                    orderby sup.SupplierName
                select new
                {
                    Country = sup.Country,
                    CompanyName = c == null ? "(No customers)" : c.CompanyName,
                    SupplierName = sup.SupplierName
                };

            foreach (var item in supplierCusts)
            {
                Console.WriteLine("{0} ({1}): {2}", item.SupplierName, item.Country, item.CompanyName);
            }
        }

        /// <summary>
        /// 对编联查询的结果，进行一些处理：SupplierName = s == null ? "(No suppliers)" : s.SupplierName
        /// </summary>
        [Description("For each customer in the table of customers, this query returns all the suppliers " +
                     "from that same country, or else a string indicating that no suppliers from that country were found.")]
        public void Linq106()
        {

            List<Customer> customers = DataRepository.GetCustomers();
            List<Supplier> suppliers = DataRepository.GetSuppliers();

            var custSuppliers =
                from cust in customers
                join sup in suppliers on cust.Country equals sup.Country into ss
                from s in ss.DefaultIfEmpty()
                orderby cust.CompanyName
                select new
                {
                    Country = cust.Country,
                    CompanyName = cust.CompanyName,
                    SupplierName = s == null ? "(No suppliers)" : s.SupplierName
                };

            foreach (var item in custSuppliers)
            {
                Console.WriteLine("{0} ({1}): {2}", item.CompanyName, item.Country, item.SupplierName);
            }
        }

        /// <summary>
        /// 使用匿名对象作为编联条件的例子
        /// </summary>
        public void Linq107()
        {
            List<Customer> customers = DataRepository.GetCustomers();
            List<Supplier> suppliers = DataRepository.GetSuppliers();

            var supplierCusts =
                from sup in suppliers
                join cust in customers on new { sup.City, sup.Country } equals new { cust.City, cust.Country } into cs
                from c in cs.DefaultIfEmpty() 
                    orderby sup.SupplierName
                select new
                {
                    Country = sup.Country,
                    City = sup.City,
                    SupplierName = sup.SupplierName,
                    CompanyName = c == null ? "(No customers)" : c.CompanyName
                };

            foreach (var item in supplierCusts)
            {
                Console.WriteLine("{0} ({1}, {2}): {3}", item.SupplierName, item.City, item.Country, item.CompanyName);
            }
        }

    }
}
