using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningDemoForLINQ.Ultilities
{
    /// <summary>
    /// 自定义的两个字符串的相等性比较(两个字符串中只要包含有相同的字符就认为相等)
    /// 继承自相等性比较运算符：IEqualityComparer<T>
    /// </summary>
    public class AnagramEqualityComparer : IEqualityComparer<string>
    {
        public bool Equals(string x, string y)
        {
            return getCanonicalString(x) == getCanonicalString(y);
        }

        public int GetHashCode(string obj)
        {
            return getCanonicalString(obj).GetHashCode();
        }

        /// <summary>
        /// 将传入处理的字符串重新排序后返回，供相等性
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        private string getCanonicalString(string word)
        {
            char[] wordChars = word.ToCharArray();
            Array.Sort<char>(wordChars);
            return new string(wordChars);
        }
    }
}
