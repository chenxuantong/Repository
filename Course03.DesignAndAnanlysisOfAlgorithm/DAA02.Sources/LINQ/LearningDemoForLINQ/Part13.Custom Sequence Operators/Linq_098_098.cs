using LearningDemoForLINQ.Ultilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningDemoForLINQ.Part13.Custom_Sequence_Operators
{
    /// <summary>
    /// 自定义的扩展序列应用运算符
    /// </summary>
    public class Linq_098_098
    {
        private DataSet _TestDS;

        public Linq_098_098()
        {
            this._TestDS= DataSetHelper.CreateTestDataset();
        }

        /// <summary>
        /// 使用用户自己定义的 Combine 运算符对两个整型数数组进行处理
        /// 参见：LearningDemoForLINQ.Ultilities.CustomSequenceOperators
        /// </summary>
        [Description("This sample uses a user-created sequence operator, Combine, to calculate the " +
             "dot product of two vectors.")]
        public void Linq098()
        {
            // 数据元素：int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            var numbersA = _TestDS.Tables["NumbersA"].AsEnumerable(); // 转型为 IEnumerable<DataRow> 
            // 数据元素：int[] numbersB = { 1, 3, 5, 7, 8 };
            var numbersB = _TestDS.Tables["NumbersB"].AsEnumerable(); // 转型为 IEnumerable<DataRow> 
            // 构建两个 DataRow 对象数据进行计算的Lamda表达式
            Func<DataRow, DataRow, int> expression = (a, b) => a.Field<int>("number") * b.Field<int>("number");

            var results = numbersA.Combine(numbersB, expression);
            foreach(var item in results)
            {
                Console.WriteLine(item);
            }

            int dotProduct = numbersA.Combine(numbersB, (a, b) => a.Field<int>("number") * b.Field<int>("number")).Sum();

            Console.WriteLine("点积的和是： {0}", dotProduct);
        }

    }
}
