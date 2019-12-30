using CDS000.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDS005.IListWithGenericsDemo
{
    /// <summary>
    /// 自定义对 IList<Person> 的一个实现，
    /// 基本上可以参考 SimpleList:IList 的具体实现来进行处理的
    /// </summary>
    public class PersonList : IList<Person>
    {
        private ArrayList _contents = new ArrayList();
        private int _count;

        /// <summary>
        /// 根据下标值返回集合数据元素
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Person this[int index]
        {
            get
            {
                return (Person)_contents[index];
            }

            set
            {
                _contents[index] = value;
            }
        }

        /// <summary>
        /// 集合数据元素数量
        /// </summary>
        public int Count
        {
            get
            {
                return _count;
            }
        }

        /// <summary>
        /// 是否只读
        /// </summary>
        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// 添加一个数据元素
        /// </summary>
        /// <param name="item"></param>
        public void Add(Person item)
        {
            _contents.Add(item);
            _count++;

        }

        /// <summary>
        /// 清空数据元素
        /// </summary>
        public void Clear()
        {
            _count = 0;
        }

        /// <summary>
        /// 是否包含有指定的数据元素对象
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Contains(Person item)
        {
            var inList = false;
            for (int i = 0; i < Count; i++)
            {
                if (_contents[i] == item)
                {
                    inList = true;
                    break;
                }
            }
            return inList;
        }

        /// <summary>
        /// 在指定的位置开始将指定的数据元素数组拷贝进去
        /// </summary>
        /// <param name="array"></param>
        /// <param name="arrayIndex"></param>
        public void CopyTo(Person[] array, int arrayIndex)
        {
            var j = arrayIndex;
            for (int i = 0; i < Count; i++)
            {
                array.SetValue(_contents[i], j);
                j++;
            }
        }

        /// <summary>
        /// 处理枚举子
        /// </summary>
        /// <returns></returns>
        public IEnumerator<Person> GetEnumerator()
        {
            return new PersonEnumerator(this);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return new PersonEnumerator(this);
        }

        /// <summary>
        /// 提取指定的数据元素的下标
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int IndexOf(Person item)
        {
            var itemIndex = -1;
            for (int i = 0; i < Count; i++)
            {
                if (_contents[i] == item)
                {
                    itemIndex = i;
                    break;
                }
            }
            return itemIndex;
        }

        /// <summary>
        /// 在指定的位置插入指定的数据元素
        /// </summary>
        /// <param name="index"></param>
        /// <param name="item"></param>
        public void Insert(int index, Person item)
        {
            if ((_count + 1 <= _contents.Count) && (index < Count) && (index >= 0))
            {
                _count++;

                for (int i = Count - 1; i > index; i--)
                {
                    _contents[i] = _contents[i - 1];
                }
                _contents[index] = item;
            }
        }

        /// <summary>
        /// 移除指定的数据元素
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Remove(Person item)
        {
            RemoveAt(IndexOf(item));
            return true;
        }

        /// <summary>
        /// 移除指定下标位置的数据元素
        /// </summary>
        /// <param name="index"></param>
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

    }

    /// <summary>
    /// 定义 PersonList 的枚举子
    /// </summary>
    public class PersonEnumerator : IEnumerator<Person>
    {
        private PersonList _collection;
        private int curIndex;
        private Person curPerson;


        public PersonEnumerator(PersonList collection)
        {
            _collection = collection;
            curIndex = -1;
            curPerson = default(Person);

        }

        public bool MoveNext()
        {
            // 避免枚举到集合外部
            if (++curIndex >= _collection.Count)
            {
                return false;
            }
            else
            {
                // 将当前的指向下一个元素
                curPerson = _collection[curIndex];
            }
            return true;
        }

        public void Reset() { curIndex = -1; }

        void IDisposable.Dispose() { }

        public Person Current
        {
            get { return curPerson; }
        }

        object IEnumerator.Current
        {
            get { return Current; }
        }

    }

}
