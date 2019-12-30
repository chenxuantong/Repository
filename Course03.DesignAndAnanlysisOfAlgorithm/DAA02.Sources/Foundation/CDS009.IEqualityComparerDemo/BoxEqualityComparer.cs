using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDS009.IEqualityComparerDemo
{
    /// <summary>
    /// 两个盒子相等性比较
    /// </summary>
    public class BoxEqualityComparer : IEqualityComparer<Box>
    {
        public bool Equals(Box b1, Box b2)
        {
            if (b2 == null && b1 == null)
                return true;
            else if (b1 == null | b2 == null)
                return false;
            else
                return b1.Height == 
                    b2.Height && b1.Length == 
                    b2.Length && b1.Width == 
                    b2.Width;
        }

        public int GetHashCode(Box bx)
        {
            var hCode = bx.Height ^ bx.Length ^ bx.Width;
            return hCode.GetHashCode();
        }
    }
}
