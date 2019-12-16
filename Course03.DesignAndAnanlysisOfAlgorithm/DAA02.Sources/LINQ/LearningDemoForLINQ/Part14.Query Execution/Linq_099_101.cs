using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningDemoForLINQ.Part14.Query_Execution
{
    /// <summary>
    /// 用于演示说明查询是如何执行生效的范例
    /// </summary>
    public class Linq_099_101
    {
        /// <summary>
        /// 使用一个整型数数组，演示演示在 foreach 枚举之前，查询的执行情况
        /// </summary>
        [Description("The following sample shows how query execution is deferred until the query is " +
                     "enumerated at a foreach statement.")]
        public void Linq099()
        {

            // 在没有进行过枚举之前，查询是无效的。
            int[] numbers = new int[] { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            int i = 0;
            var simpleQuery =
                from num in numbers
                select ++i;

            Console.WriteLine("当前 i 的值是： {0}", i); // i 还是 0

            foreach (var item in simpleQuery)
            {
                Console.WriteLine("数组元素 = {0}, i = {1}", item, i);          
            }
        }

        /// <summary>
        /// 演示一些方法和查询执行的情况
        /// </summary>
        public void Linq100()
        {

            // 方法 ToList(), Max(), 和 Count() 会直接导致查询执行
            int[] numbers = new int[] { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            int i = 0;
            var immediateQuery = (
                from num in numbers
                select ++i)
                .ToList();

            Console.WriteLine("当前 i 的值是： {0}", i); 

            foreach (var item in immediateQuery)
            {
                Console.WriteLine("数组元素 = {0}, i = {1}", item, i);
            }
        }

        /// <summary>
        /// 应用延迟查询的例子
        /// </summary>
        public void Linq101()
        {

            // Deferred execution lets us define a query once
            // and then reuse it later in various ways.
            // 先定义一个延迟查询，可以用在后面的地方
            int[] numbers = new int[] { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var lowNumbers =
                from num in numbers
                where num <= 3
                select num;

            Console.WriteLine("执行第一个查询");
            foreach (int n in lowNumbers)
            {
                Console.WriteLine(n);
            }

            // 对 lowNumbers 再定义一个查询
            var lowEvenNumbers =
                from num in lowNumbers
                where num % 2 == 0
                select num;

            Console.WriteLine("执行第二个查询：");
            foreach (int n in lowEvenNumbers)
            {
                Console.WriteLine(n);
            }

            // 调整数据
            for (int i = 0; i < 10; i++)
            {
                numbers[i] = -numbers[i];
            }

            Console.WriteLine("调整数据之后的 lowNumbers 查询结果集合：");
            foreach (int n in lowNumbers)
            {
                Console.WriteLine(n);
            }
        }
    }
}
