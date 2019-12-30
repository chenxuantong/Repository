using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDS003.ICollectionWithGenericsDemo
{
    /// <summary>
    /// 相同的体积定义为相同的盒子
    /// </summary>
    public class BoxSameVolume : EqualityComparer<Box>
    {
        public override bool Equals(Box b1, Box b2) => 
            (b1.Height * b1.Length * b1.Width) == (b2.Height * b2.Length * b2.Width)
            ? true : false;

        public override int GetHashCode(Box bx)
        {
            var hCode = bx.Height ^ bx.Length ^ bx.Width;
            Console.WriteLine("HC: {0}", hCode.GetHashCode());
            return hCode.GetHashCode();
        }
    }
}
