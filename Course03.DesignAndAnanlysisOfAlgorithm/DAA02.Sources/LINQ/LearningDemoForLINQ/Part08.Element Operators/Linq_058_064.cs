using LearningDemoForLINQ.Entities;
using LearningDemoForLINQ.Ultilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningDemoForLINQ.Part08.Element_Operators
{
    /// <summary>
    /// 演示数据集合中与单一元素操作相关的运算符
    /// </summary>
    public class Linq_058_064
    {
        /// <summary>
        /// 使用 First 从产品数据集合中找出产品标识（ProductID）为 12 的元素（产品）
        /// </summary>
        public void Linq058()
        {
            List<Product> products = DataRepository.GetProducts();

            Product product12 = (
                from prod in products
                where prod.ProductID == 12
                select prod)
                .First();

            ObjectDumper.Write(product12);
        }

        /// <summary>
        /// 使用 First 从一个字符串集合中每个元素的第一个字符为 o 的所有元素抽取第一个
        /// </summary>
        public void Linq059()
        {
            string[] strings = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            string startsWithO = strings.First(s => s[0] == 'o');

            Console.WriteLine("以 'o' 开头的第一个字符串: {0}", startsWithO);
        }

        /// <summary>
        /// 使用 FirstOrDefault 返回第一个元素，如果集合或者在 where 约束后的集合为空，则返回一个空类型
        /// </summary>
        public void Linq061()
        {
            int[] numbers = { };

            int firstNumOrDefault = numbers.FirstOrDefault();

            Console.WriteLine(firstNumOrDefault);
        }

        /// <summary>
        /// 使用 FirstOrDefault 返回产品数据集合中，产品标识码为 789 的产品，判断这个产品是否存在
        /// </summary>
        public void Linq062()
        {
            List<Product> products = DataRepository.GetProducts();

            Product product789 = products.FirstOrDefault(p => p.ProductID == 789);

            Console.WriteLine("产品 789 是否存在： {0}", product789 != null);
        }

        /// <summary>
        /// 使用 ElementAt 访问一个整数集合中，所有大于5 的第二个整数 
        /// </summary>
        public void Linq064()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            int fourthLowNum = (
                from num in numbers
                where num > 5
                select num)
                .ElementAt(1); 

            Console.WriteLine("大于5的第二个整数：{0}", fourthLowNum);
        }

    }
}
