using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDS003.ICollectionWithGenericsDemo
{
    /// <summary>
    /// 课程范例所需要的模型：盒子（立方体）
    /// </summary>
    public class Box : IEquatable<Box>
    {
        public Box(int h, int l, int w)
        {
            this.Height = h;
            this.Length = l;
            this.Width = w;
        }
        public int Height { get; set; }
        public int Length { get; set; }
        public int Width { get; set; }

        // 使用 BoxSameDimensions 定义相等性
        public bool Equals(Box other)
        {
            return new BoxSameDimensions().Equals(this, other) ? true : false;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

}
