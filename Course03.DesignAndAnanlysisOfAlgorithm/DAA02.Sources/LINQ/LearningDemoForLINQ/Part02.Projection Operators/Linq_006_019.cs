using LearningDemoForLINQ.Ultilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningDemoForLINQ.Part02.Projection_Operators
{
    /// <summary>
    /// 用演示查询选择器 select 相关应用的范例，范例中使用了数据集合 DataSet 作为数据源
    /// </summary>
    public class Linq_006_019
    {
        private DataSet _TestDS;

        public Linq_006_019()
        {
            _TestDS = DataSetHelper.CreateTestDataset();
        }

        /// <summary>
        /// 使用 select 从已经存在的数据集的数据表 Numbers 的元素中，生成一个比原来 +1 的新的数据集合
        /// 源数据集合元素： 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 
        /// </summary>
        public void Linq006()
        {
            var numbers = _TestDS.Tables["Numbers"].AsEnumerable();   // 将数据表元素转型为 IEnumerable<T>，当前泛型是 int

            var numsPlusOne =
                from n in numbers
                select n.Field<int>(0) + 1;

            Console.WriteLine("Numbers + 1:");
            foreach (var i in numsPlusOne)
            {
                Console.WriteLine(i);
            }
        }

        /// <summary>
        /// 使用 select 从数据集的产品数据表中，只提取产品名称，构建一个新的产品名称的集合
        /// </summary>
        public void Linq007()
        {
            var products = _TestDS.Tables["Products"].AsEnumerable();

            var productNames =
                from p in products
                select p.Field<string>("ProductName");

            Console.WriteLine("所有的产品名称：");
            foreach (var productName in productNames)
            {
                Console.WriteLine(productName);
            }
        }

        /// <summary>
        /// 使用 select 从数据表 Numbers 的元素中，提取相应的整形数据，并将这些数据作为索引，
        /// 从 string[] 中检索出相应的字符串，构建一个新的数据集合。
        /// Tables["Numbers"]的数据元素：5, 4, 1, 3, 9, 8, 6, 7, 2, 0
        /// 变量 strings 的数据源："zero", "one", "two", "three", "four", "five", "six",
        /// "seven", "eight", "nine"
        /// </summary>
        public void Linq008()
        {

            var numbers = _TestDS.Tables["Numbers"].AsEnumerable();
            string[] strings = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var textNums = numbers.Select(p => strings[p.Field<int>("number")]);

            Console.WriteLine("Number strings:");
            foreach (var s in textNums)
            {
                Console.WriteLine(s);
            }
        }

        /// <summary>
        /// 使用 select 从数据表 Words 构建全是大写、小写的新的数据集合
        /// </summary>
        public void Linq009()
        {

            var words = _TestDS.Tables["Words"].AsEnumerable();

            var upperLowerWords = words.Select(p => new
            {
                Upper = (p.Field<string>(0)).ToUpper(),
                Lower = (p.Field<string>(0)).ToLower()
            });

            foreach (var ul in upperLowerWords)
            {
                Console.WriteLine("大写： " + ul.Upper + ", 小写" + ul.Lower);
            }
        }

        /// <summary>
        /// 使用 select 从数据表 Numbers 和 Digits 中构建一个新的数据集合，集合的元素为：
        ///     数字字符串：根据 Numbers 的元素作为索引，在 Digits 中抽取对应的值；
        ///     是否是偶数：对选中的元素进行处理判断后赋值。
        /// Tables["Numbers"]的元素：5, 4, 1, 3, 9, 8, 6, 7, 2, 0
        /// Tables["Digits"]的元素："zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" 
        /// </summary>
        public void Linq010()
        {

            var numbers = _TestDS.Tables["Numbers"].AsEnumerable();
            var digits = _TestDS.Tables["Digits"];

            var digitOddEvens = numbers.
                Select(n => new
                {
                    Digit = digits.Rows[n.Field<int>("number")]["digit"],
                    Even = (n.Field<int>("number") % 2 == 0)
                });

            foreach (var d in digitOddEvens)
            {
                Console.WriteLine("数字 {0} 是 {1}.", d.Digit, d.Even ? "偶数" : "奇数");
            }
        }

        /// <summary>
        /// 使用 select 从商品数据表 Products 中抽取部分属性（例如：ProductName，Category，UnitPrice），构建一个新的数据集合，
        /// 其中还可以将 Product 属性的名称根据需要重新命名，例如将 UnitPrice 更改为 Price。
        /// </summary>
        public void Linq011()
        {
            var products = _TestDS.Tables["Products"].AsEnumerable();

            var productInfos = products.
                Select(n => new
                {
                    ProductName = n.Field<string>("ProductName"),
                    Category = n.Field<string>("Category"),
                    Price = n.Field<decimal>("UnitPrice")
                });

            Console.WriteLine("产品的基本信息：");
            foreach (var productInfo in productInfos)
            {
                Console.WriteLine("产品：{0} 是属于 {1} 类别的，它的单价是： {2} 。", productInfo.ProductName, productInfo.Category, productInfo.Price);
            }
        }

        /// <summary>
        /// 使用 select 索引从从数据表 Numbers 中选择出数值和它的索引位置，并且判断两者是否，构建一个新的元素集合。
        /// Tables["Numbers"]的元素：5, 4, 1, 3, 9, 8, 6, 7, 2, 0
        /// </summary>
        public void Linq012()
        {
            var numbers = _TestDS.Tables["Numbers"].AsEnumerable();

            var numsInPlace = numbers.Select((num, index) => new
            {
                Num = num.Field<int>("number"),
                InPlace = (num.Field<int>("number") == index)
            });

            Console.WriteLine("数字：值与索引是否相等？");
            foreach (var n in numsInPlace)
            {
                Console.WriteLine("{0}: {1}", n.Num, n.InPlace);
            }
        }

        /// <summary>
        /// 根据数据表 Numbers 和 Digits 的内容，使用 select 和 where 构建一个简单的查询，
        /// 从 Numbers 中选择所有小于 5 的元素，然后根据 Digits 中的元素定义，返回对应的字符串文本。
        /// Tables["Numbers"]的元素：5, 4, 1, 3, 9, 8, 6, 7, 2, 0
        /// Tables["Digits"]的元素："zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" 
        /// </summary>
        public void Linq013()
        {
            var numbers = _TestDS.Tables["Numbers"].AsEnumerable();
            var digits = _TestDS.Tables["Digits"];

            var lowNums =
                from n in numbers
                where n.Field<int>("number") < 5
                select digits.Rows[n.Field<int>("number")].Field<string>("digit");

            Console.WriteLine("数据表 Numbers < 5 元素对应的 Digits 文本：");
            foreach (var num in lowNums)
            {
                Console.WriteLine(num);
            }
        }

        /// <summary>
        /// 从数据表 NumbersA，NumbersB 中，分别从两个集合中选择两个数据元素构成一个对子，挑选前者的数据元素小于后者的元素，构建一个新的数据集合
        /// Tables["NumbersA"]的数据元素：0, 2, 4, 5, 6, 8, 9 
        /// Tables["NumbersB"]的数据元素：1, 3, 5, 7, 8
        /// </summary>
        public void Linq014()
        {

            var numbersA = _TestDS.Tables["NumbersA"].AsEnumerable();
            var numbersB = _TestDS.Tables["NumbersB"].AsEnumerable();

            var pairs =
                from a in numbersA
                from b in numbersB
                where a.Field<int>("number") < b.Field<int>("number")
                select new { a = a.Field<int>("number"), b = b.Field<int>("number") };

            Console.WriteLine("满足 a < b 条件的所有的数据对子：");
            foreach (var pair in pairs)
            {
                Console.WriteLine("{0} 小于 {1}", pair.a, pair.b);
            }
        }

        /// <summary>
        /// 从客户和订单两个数据表中，选择那些订单金额少于 500 的订单
        /// </summary>
        public void Linq015()
        {
            var customers = _TestDS.Tables["Customers"].AsEnumerable();
            var orders = _TestDS.Tables["Orders"].AsEnumerable();

            var smallOrders =
                from c in customers
                from o in orders
                where c.Field<string>("CustomerID") == o.Field<string>("CustomerID")
                    && o.Field<decimal>("Total") < 500.00M
                select new
                {
                    CustomerID = c.Field<string>("CustomerID"),
                    OrderID = o.Field<int>("OrderID"),
                    Total = o.Field<decimal>("Total")
                };

            ObjectDumper.Write(smallOrders);
        }

        /// <summary>
        /// 从客户和订单两个数据表中，选择那些下单日期在 1998 年以及其后的订单。
        /// </summary>
        public void Linq016()
        {

            var customers = _TestDS.Tables["Customers"].AsEnumerable();
            var orders = _TestDS.Tables["Orders"].AsEnumerable();

            var myOrders =
                from c in customers
                from o in orders
                where c.Field<string>("CustomerID") == o.Field<string>("CustomerID") &&
                o.Field<DateTime>("OrderDate") >= new DateTime(1998, 1, 1)
                select new
                {
                    CustomerID = c.Field<string>("CustomerID"),
                    OrderID = o.Field<int>("OrderID"),
                    OrderDate = o.Field<DateTime>("OrderDate")
                };

            ObjectDumper.Write(myOrders);
        }

        /// <summary>
        /// 从客户和订单两个数据表中，选择那些订单大于 2000，并通过对订单金额赋值条件来处理避免重复请求代码的情况
        /// </summary>
        public void Linq017()
        {

            var customers = _TestDS.Tables["Customers"].AsEnumerable();
            var orders = _TestDS.Tables["Orders"].AsEnumerable();

            var myOrders =
                from c in customers
                from o in orders
                let total = o.Field<decimal>("Total")
                where c.Field<string>("CustomerID") == o.Field<string>("CustomerID")
                    && total >= 2000.0M
                select new { CustomerID = c.Field<string>("CustomerID"), OrderID = o.Field<int>("OrderID"), total };

            ObjectDumper.Write(myOrders);
        }

        /// <summary>
        /// 从客户和订单两个数据表中，选择那些客户属于 WA 区域的，并且是指定的下单日期（DateTime(1997, 1, 1)）的订单数据
        /// </summary>
        public void Linq018()
        {

            var customers = _TestDS.Tables["Customers"].AsEnumerable();
            var orders = _TestDS.Tables["Orders"].AsEnumerable();
            DateTime cutoffDate = new DateTime(1997, 1, 1);

            var myOrders =
                from c in customers
                where c.Field<string>("Region") == "WA"   // 客户属于 WA 区域的
                from o in orders
                where c.Field<string>("CustomerID") == o.Field<string>("CustomerID") && (DateTime)o["OrderDate"] >= cutoffDate  // 并且是指定的下单日期
                select new { CustomerID = c.Field<string>("CustomerID"), OrderID = o.Field<int>("OrderID") };

            ObjectDumper.Write(myOrders);
        }

        /// <summary>
        /// 使用 SelectMany 从客户和订单两个数据表中，选择全部的订单和订单索引
        /// 1.先选择全部的客户和客户索引；
        /// 2.过滤提取和客户关联的订单；
        /// 3.选择将客户索引和订单标识符构建新的查询结果元素集合。
        /// </summary>
        public void Linq019()
        {

            var customers = _TestDS.Tables["Customers"].AsEnumerable();
            var orders = _TestDS.Tables["Orders"].AsEnumerable();

            var customerOrders =
                customers.SelectMany(
                    (cust, custIndex) =>
                    orders.Where(o => cust.Field<string>("CustomerID") == o.Field<string>("CustomerID"))
                        .Select(o => new { CustomerIndex = custIndex + 1, OrderID = o.Field<int>("OrderID") }));

            foreach (var c in customerOrders)
            {
                Console.WriteLine("客户的索引： " + c.CustomerIndex + "；拥有订单号为：" + c.OrderID+" 的订单。");
            }
        }
    }
}
