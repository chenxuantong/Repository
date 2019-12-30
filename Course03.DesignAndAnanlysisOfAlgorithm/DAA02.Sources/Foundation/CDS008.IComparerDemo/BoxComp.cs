using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDS008.IComparerDemo
{
    public class BoxComp : IComparer<Box>
    {
        /// <summary>
        /// 比较两个盒子的是否相等
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>返回值是 0 则相等</returns>
        public int Compare(Box x, Box y)
        {
            if (x.Height.CompareTo(y.Height) != 0)
            {
                return x.Height.CompareTo(y.Height);
            }
            else if (x.Length.CompareTo(y.Length) != 0)
            {
                return x.Length.CompareTo(y.Length);
            }
            else if (x.Width.CompareTo(y.Width) != 0)
            {
                return x.Width.CompareTo(y.Width);
            }
            else
            {
                return 0;
            }
        }
    }
}
