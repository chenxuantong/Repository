using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDS003.ICollectionWithGenericsDemo
{
    /// <summary>
    /// 自定义 ICollection<T> 的实现
    /// </summary>
    public class BoxCollection : ICollection<Box>
    {
        // 泛型枚举子来自 GetEnumerator 生成的 IEnumerator<Box> 也还可以用于非泛型的枚举子
        // 为了避免名字矛盾，非泛型的需要另外的明确定义。

        public IEnumerator<Box> GetEnumerator()
        {
            return new BoxEnumerator(this);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return new BoxEnumerator(this);
        }

        // 这个内嵌的集合存储对象元素集合
        private List<Box> innerCol;

        public BoxCollection()
        {
            innerCol = new List<Box>();
        }

        // 为集合添加元素索引
        public Box this[int index]
        {
            get { return (Box)innerCol[index]; }
            set { innerCol[index] = value; }
        }

        // 使用 BoxSameDimensions 比较器检查某个元素是否在集合中
        public bool Contains(Box item)
        {
            bool found = false;

            foreach (Box bx in innerCol)
            {
                // 在 Box 中实现 IEquitable<T> 的方法
                if (bx.Equals(item))
                {
                    found = true;
                }
            }

            return found;
        }

        // 使用自定义规格比较器，检查传入的 item 是否 包含在集合中
        public bool Contains(Box item, EqualityComparer<Box> comp)
        {
            bool found = false;

            foreach (Box bx in innerCol)
            {
                if (comp.Equals(bx, item))
                {
                    found = true;
                }
            }

            return found;
        }

        // 将盒子添加到集合中
        public void Add(Box item)
        {

            if (!Contains(item))
            {
                innerCol.Add(item);
            }
            else
            {
                Console.WriteLine("规格为 {0}x{1}x{2} 的盒子已经添加到集合中了。",
                    item.Height.ToString(), item.Length.ToString(), item.Width.ToString());
            }
        }

        // 清除
        public void Clear()
        {
            innerCol.Clear();
        }

        // 拷贝
        public void CopyTo(Box[] array, int arrayIndex)
        {
            if (array == null)
                throw new ArgumentNullException("对象数组不能为空值。");
            if (arrayIndex < 0)
                throw new ArgumentOutOfRangeException("起始索引值不能为负数。");
            if (Count > array.Length - arrayIndex + 1)
                throw new ArgumentException("目标数组的长度不足以添加你传进来的数据元素。");

            for (int i = 0; i < innerCol.Count; i++)
            {
                array[i + arrayIndex] = innerCol[i];
            }
        }

        //计数
        public int Count
        {
            get
            {
                return innerCol.Count;
            }
        }

        // 是否只读
        public bool IsReadOnly
        {
            get { return false; }
        }

        // 移除
        public bool Remove(Box item)
        {
            bool result = false;

            for (int i = 0; i < innerCol.Count; i++)
            {
                Box curBox = (Box)innerCol[i];

                if (new BoxSameDimensions().Equals(curBox, item))
                {
                    innerCol.RemoveAt(i);
                    result = true;
                    break;
                }
            }
            return result;
        }

    }
}
