using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningDemoForLINQ.Ultilities
{
    /// <summary>
    /// 自定义的一些查询方法
    /// </summary>
    public static class CustomSequenceOperators
    {
        /// <summary>
        /// 扩展 IEnumerable<DataRow> 的方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="first">第一组 IEnumerable<DataRow> 对象</param>
        /// <param name="second">第二组 IEnumerable<DataRow> 对象</param>
        /// <param name="func">前端传入的 两组对象逐个进行运算的计算 Lambda 表达式</param>
        /// <returns></returns>
        public static IEnumerable<T> Combine<T>(
            this IEnumerable<DataRow> first,       // 待扩展的 IEnumerable 集合（源）
            IEnumerable<DataRow> second,           // 用于关联处理的 IEnumerable 集合
            System.Func<DataRow, DataRow, T> func  // Lambda 表达式
            )
        {
            using (IEnumerator<DataRow> e1 = first.GetEnumerator(), e2 = second.GetEnumerator())  // 分别枚举集合元素
            {
                while (e1.MoveNext() && e2.MoveNext())   // 如果同时还存在后续元素
                {
                    yield return func(e1.Current, e2.Current);  // 返回 func 对当前两个元素的处理结果
                }
            }
        }
    }
}
