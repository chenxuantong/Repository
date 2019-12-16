using LearningDemoForLINQ.Entities;
using LearningDemoForLINQ.Ultilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningDemoForLINQ.Part10.Quantifiers
{
    /// <summary>
    /// 用于演示数据集合元素计量相关的操作方法的应用
    /// </summary>
    public class Linq_067_072
    {
        /// <summary>
        /// 使用 Any 判断字符串集合中是否存在包含子串 “ei” 的字符串
        /// </summary>
        public void Linq067()
        {
            string[] words = { "believe", "relief", "receipt", "field" };

            bool iAfterE = words.Any(w => w.Contains("ei"));

            Console.WriteLine("包含有 'ei' 的字符串是： {0}", iAfterE);
        }

        /// <summary>
        /// 使用 Any 判断经过按照产品类型分组的产品中，只要存在库存数量为零的 产品分组
        /// </summary>
        public void Linq069()
        {
            List<Product> products = DataRepository.GetProducts(); 

            var productGroups =
                from prod in products
                group prod by prod.Category into prodGroup
                where prodGroup.Any(p => p.UnitsInStock == 0)
                select new { Category = prodGroup.Key, Products = prodGroup };

            ObjectDumper.Write(productGroups, 1);
        }

        /// <summary>
        /// 使用 All 判断一个整数集合中，是否全都是奇数
        /// </summary>
        public void Linq070()
        {
            int[] numbers = { 1, 11, 3, 19, 41, 65, 19 };

            bool onlyOdd = numbers.All(n => n % 2 == 1);

            Console.WriteLine("这个整数集合是否完全由奇数组成： {0}", onlyOdd);
        }

        /// <summary>
        /// 使用 All 判断经过按照产品类型分组的产品中，只要存在库存数量大于零的产品分组
        /// </summary>
        public void Linq072()
        {
            List<Product> products = DataRepository.GetProducts();

            var productGroups =
                from prod in products
                group prod by prod.Category into prodGroup
                where prodGroup.All(p => p.UnitsInStock > 0)
                select new { Category = prodGroup.Key, Products = prodGroup };

            ObjectDumper.Write(productGroups, 1);
        }
    }
}
