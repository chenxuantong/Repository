using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 计算年龄
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = "";
            var day = 0;
            var now = DateTime.Now;
            ListClass list = new ListClass();
            foreach (var item in list.InitialPersonList())
            {
                day = day + Math.Abs(((TimeSpan)(now - item.Birthday)).Days);
            }

            var avgday = day / list.InitialPersonList().Count;
            var avgYears = avgday / 365;
            var avgDays = avgday - avgYears * 365;

            result = "平均年龄：" + avgYears + "周岁" + "-" + avgDays + "天";
            Console.WriteLine(result);
            GetName(list.InitialPersonList());
        }
        public static void GetName(List<Person> persons)
        {
            var result1 = from i in persons
                          where i.Name.Contains("欧阳")
                          group i by i.Name.Substring(0, 2)
                          into g
                          select new { g.Key, sum = g.Count() };
            var result2 = from i in persons
                          where !i.Name.Contains("欧阳")
                          group i by i.Name.Substring(0, 1)
                          into g
                          select new { g.Key, sum = g.Count() };
            foreach (var x in result2)
            {
                Console.Write("姓氏：{0}\t{1}人\n", x.Key, x.sum);
            }
            foreach (var x in result1)
            {
                Console.Write("姓氏：{0}\t{1}人\n", x.Key, x.sum);
            }
        }
    }
    }
}
