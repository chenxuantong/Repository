using LearningDemoForLINQ.Ultilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningDemoForLINQ.Part05.Grouping_Operators
{
    /// <summary>
    /// 用于演示说明应用 GroupBy 运算符的范例
    /// </summary>
    public class Linq_040_045
    {
        private DataSet _TestDS;

        public Linq_040_045()
        {
            _TestDS = DataSetHelper.CreateTestDataset();
        }

        /// <summary>
        /// 使用 GroupBy 分解一个数字集合，使得按照集合元素被5除后的余数进行分组
        /// </summary>
        public void Linq040()
        {

            var numbers = _TestDS.Tables["Numbers"].AsEnumerable();

            var numberGroups =
                from n in numbers
                group n by n.Field<int>("number") % 5 into g
                select new { Remainder = g.Key, Numbers = g };

            foreach (var g in numberGroups)
            {
                Console.WriteLine("被 5 除后的余数为 {0} 的数字如下:", g.Remainder);
                foreach (var n in g.Numbers)
                {
                    Console.WriteLine(n.Field<int>("number"));
                }
            }
        }

        /// <summary>
        /// 使用 group by 将一个列表按照第一个字母进行分组
        /// </summary>
        public void Linq041()
        {

            var words4 = _TestDS.Tables["Words4"].AsEnumerable();

            var wordGroups =
                from w in words4
                group w by w.Field<string>("word")[0] into g
                select new { FirstLetter = g.Key, Words = g };

            foreach (var g in wordGroups)
            {
                Console.WriteLine("首字母为 '{0}' 的结果:", g.FirstLetter);
                foreach (var w in g.Words)
                {
                    Console.WriteLine(w.Field<string>("word"));
                }
            }
        }

        /// <summary>
        /// 这个例子将产品按照类别进行分组
        /// </summary>
        public void Linq042()
        {

            var products = _TestDS.Tables["Products"].AsEnumerable();

            var productGroups =
                from p in products
                group p by p.Field<string>("Category") into g
                select new { Category = g.Key, Products = g };

            foreach (var g in productGroups)
            {
                Console.WriteLine("产品分类: {0}", g.Category);
                foreach (var w in g.Products)
                {
                    Console.WriteLine("\t" + w.Field<string>("ProductName"));
                }
            }
        }

        /// <summary>
        /// 这个例子将客户先按年度，然后按照月份进行分组
        /// </summary>
        public void Linq043()
        {

            var customers = _TestDS.Tables["Customers"].AsEnumerable();

            var customerOrderGroups =
                from c in customers
                select
                    new
                    {
                        CompanyName = c.Field<string>("CompanyName"),
                        YearGroups =
                            from o in c.GetChildRows("CustomersOrders")
                            group o by o.Field<DateTime>("OrderDate").Year into yg
                            select
                                new
                                {
                                    Year = yg.Key,
                                    MonthGroups =
                                        from o in yg
                                        group o by o.Field<DateTime>("OrderDate").Month into mg
                                        select new { Month = mg.Key, Orders = mg }
                                }
                    };

            foreach (var cog in customerOrderGroups)
            {
                Console.WriteLine("公司名称 = {0}", cog.CompanyName);
                foreach (var yg in cog.YearGroups)
                {
                    Console.WriteLine("\t 年度= {0}", yg.Year);
                    foreach (var mg in yg.MonthGroups)
                    {
                        Console.WriteLine("\t\t 月份= {0}", mg.Month);
                        foreach (var order in mg.Orders)
                        {
                            Console.WriteLine("\t\t\t 订单编号= {0} ", order.Field<int>("OrderID"));
                            Console.WriteLine("\t\t\t 下单日期= {0} ", order.Field<DateTime>("OrderDate"));
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 使用 GroupBy 将一个字符串集合元素去掉空格以后，按照自定义的相等性运算符判断分组依据进行分组
        /// </summary>
        public void Linq044()
        {
            var anagrams = _TestDS.Tables["Anagrams"].AsEnumerable();  // 实际的数据是：{ "from   ", " salt", " earn ", "  last   ", " near ", " form  " }

            var orderGroups = anagrams.GroupBy(w => w.Field<string>("anagram").Trim(), new AnagramEqualityComparer());

            foreach (var g in orderGroups)
            {
                Console.WriteLine("Key: {0}", g.Key);
                foreach (var w in g)
                {
                    Console.WriteLine("\t" + w.Field<string>("anagram"));
                }
            }
        }

        /// <summary>
        /// 使用 GroupBy 将一个字符串集合元素去掉空格以后，使用自定义的字符串相等性比较运算符，
        /// 分别按照去掉空格的字符串，然后按照转为大写字符的方式进行分组
        /// </summary>
        public void Linq045()
        {
            var c = new CaseInsensitiveComparer();
            var b = c.Compare( "aAA","aaA");

            var anagrams = _TestDS.Tables["Anagrams"].AsEnumerable();   // 实际的数据是：{ "from   ", " salt", " earn ", "  last   ", " near ", " form  " }

            var orderGroups = anagrams.GroupBy(
                w => w.Field<string>("anagram").Trim(),
                a => a.Field<string>("anagram").ToUpper(),
                new AnagramEqualityComparer()
                );

            foreach (var g in orderGroups)
            {
                Console.WriteLine("Key: {0}", g.Key);
                foreach (var w in g)
                {
                    Console.WriteLine("\t" + w);
                }
            }
        }
    }
}
