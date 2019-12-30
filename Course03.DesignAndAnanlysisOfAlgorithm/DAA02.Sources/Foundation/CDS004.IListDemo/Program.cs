using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDS004.IListDemo
{
    class Program
    {
        static void Main()
        {
            var test = new SimpleList();

            // 初始化 test
            Console.WriteLine("初始化 List");
            test.Add("壹");
            test.Add("贰");
            test.Add("叁");
            test.Add("肆");
            test.Add("伍");
            test.Add("陆");
            test.Add("柒");
            test.Add("捌");
            test.Add("玖");
            test.PrintContents();
            Console.WriteLine();

            // 从 test 中移除元素
            Console.WriteLine("移除列表中的元素");
            test.Remove("陆");
            test.Remove("捌");
            test.PrintContents();
            Console.WriteLine();

            // 在 test 的末端添加元素
            Console.WriteLine("在列表末端添加元素");
            test.Add("拾");
            test.PrintContents();
            Console.WriteLine();

            // 在 test 的指定位置插入元素
            Console.WriteLine("在列表中指定位置插入元素");
            test.Insert(4, "number");
            test.PrintContents();
            Console.WriteLine();

            // 检查 test 中指定的元素
            Console.WriteLine("检查 列表 中指定的元素");
            Console.WriteLine("List 是否包含 \"叁\": {0}", test.Contains("叁"));
            Console.WriteLine("List 是否包含 \"捌\": {0}", test.Contains("捌"));

            Console.ReadKey();
        }
    }

    class SimpleList : IList
    {
        private object[] _contents = new object[8];
        //private ArrayList _contents = new ArrayList();
        private int _count;

        public SimpleList()
        {
            _count = 0;
        }

        // IList 成员
        public int Add(object value)
        {
            if (_count < _contents.Length)
            {
                _contents[_count] = value;
                _count++;

                return (_count - 1);
            }
            else
            {
                return -1;
            }
        }

        public void Clear()
        {
            _count = 0;
        }

        public bool Contains(object value)
        {
            var inList = false;
            for (int i = 0; i < Count; i++)
            {
                if (_contents[i] == value)
                {
                    inList = true;
                    break;
                }
            }
            return inList;
        }

        public int IndexOf(object value)
        {
            int itemIndex = -1;
            for (int i = 0; i < Count; i++)
            {
                if (_contents[i] == value)
                {
                    itemIndex = i;
                    break;
                }
            }
            return itemIndex;
        }

        public void Insert(int index, object value)
        {
            if ((_count + 1 <= _contents.Length) && (index < Count) && (index >= 0))
            {
                _count++;

                for (int i = Count - 1; i > index; i--)
                {
                    _contents[i] = _contents[i - 1];
                }
                _contents[index] = value;
            }
        }

        public bool IsFixedSize
        {
            get
            {
                return true;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public void Remove(object value)
        {
            RemoveAt(IndexOf(value));
        }

        public void RemoveAt(int index)
        {
            if ((index >= 0) && (index < Count))
            {
                for (int i = index; i < Count - 1; i++)
                {
                    _contents[i] = _contents[i + 1];
                }
                _count--;
            }
        }

        public object this[int index]
        {
            get
            {
                return _contents[index];
            }
            set
            {
                _contents[index] = value;
            }
        }

        // ICollection 的成员
        public void CopyTo(Array array, int index)
        {
            var j = index;
            for (int i = 0; i < Count; i++)
            {
                array.SetValue(_contents[i], j);
                j++;
            }
        }

        public int Count
        {
            get
            {
                return _count;
            }
        }

        public bool IsSynchronized
        {
            get
            {
                return false;
            }
        }

        // 如果下面的属性没有存储的对象，返回当前对象实例
        public object SyncRoot
        {
            get
            {
                return this;
            }
        }

        // IEnumerable 成员
        public IEnumerator GetEnumerator()
        {
            // 参考以前的例子
            throw new Exception("这个方法尚未实现。");
        }

        public void PrintContents()
        {
            Console.WriteLine("当前列表的容量是 {0} 当前拥有 {1} 个元素。", _contents.Length, _count);
            Console.Write("List 数据内容:");
            for (int i = 0; i < Count; i++)
            {
                Console.Write(" {0}", _contents[i]);
            }
            Console.WriteLine();
        }
    }

}
