using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDS006.IDictionaryDemo
{
    /// <summary>
    /// 这个类使用一个 DictionaryEntry 实体实现 “键/值对” 对象集合
    /// </summary>
    public class SimpleDictionary : IDictionary
    {
        // 元素集合
        private DictionaryEntry[] items;  // 元素集合
        private Int32 ItemsInUse = 0;     // 元素使用的数量

        /// <summary>
        /// 构造函数：定义集合元素的数量
        /// 在 SimpleDictionary 的生命周期里，这个数量是不能更改的。
        /// </summary>
        /// <param name="numItems">元素数量</param>
        public SimpleDictionary(Int32 numItems)
        {
            items = new DictionaryEntry[numItems];
        }

        #region IDictionary 成员，注意这些成员都是 IDictionary 已经定义的，在这里需要具体实现
        public bool IsReadOnly { get { return false; } }

        /// <summary>
        /// 包含
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Contains(object key)
        {
            Int32 index;
            return TryGetIndexOfKey(key, out index);
        }

        public bool IsFixedSize { get { return false; } }

        /// <summary>
        /// 移除
        /// </summary>
        /// <param name="key"></param>
        public void Remove(object key)
        {
            if (key == null) throw new ArgumentNullException("key");
            // 在 DictionaryEntry 数组中检索 key
            Int32 index;
            if (TryGetIndexOfKey(key, out index))
            {
                // 如果找到 key 则将其后面的元素，全部前移一个位置
                Array.Copy(items, index + 1, items, index, ItemsInUse - index - 1);
                ItemsInUse--;
            }
            else
            {
                // 不处理 
            }
        }

        /// <summary>
        /// 清除
        /// </summary>
        public void Clear() { ItemsInUse = 0; }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Add(object key, object value)
        {
            // 添加一个 键/值 对，即使集合已经存在相同的 key 。
            if (ItemsInUse == items.Length)
                throw new InvalidOperationException("字典无法加载更多的元素了。");
            items[ItemsInUse++] = new DictionaryEntry(key, value);
        }
        public ICollection Keys
        {
            get
            {
                Object[] keys = new Object[ItemsInUse];
                for (Int32 n = 0; n < ItemsInUse; n++)
                    keys[n] = items[n].Key;
                return keys;
            }
        }
        public ICollection Values
        {
            get
            {
                Object[] values = new Object[ItemsInUse];
                for (Int32 n = 0; n < ItemsInUse; n++)
                    values[n] = items[n].Value;
                return values;
            }
        }
        public object this[object key]
        {
            get
            {
                // 在字典中发现 key 则返回 vlaue。
                Int32 index;
                if (TryGetIndexOfKey(key, out index))
                {
                    return items[index].Value;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                //设置
                Int32 index;
                if (TryGetIndexOfKey(key, out index))
                {
                    // 如果发现 key 则修改 value.
                    items[index].Value = value;
                }
                else
                {
                    // 如果没有发现 key 则添加一个 key/value 对子
                    Add(key, value);
                }
            }
        }

        private Boolean TryGetIndexOfKey(Object key, out Int32 index)
        {
            for (index = 0; index < ItemsInUse; index++)
            {
                if (items[index].Key.Equals(key)) return true;
            }

            return false;
        }

        private class SimpleDictionaryEnumerator : IDictionaryEnumerator
        {
            DictionaryEntry[] items;
            Int32 index = -1;

            public SimpleDictionaryEnumerator(SimpleDictionary sd)
            {
                // 将字典中的对应在 SimpleDictionary 的元素拷贝出来。
                items = new DictionaryEntry[sd.Count];
                Array.Copy(sd.items, 0, items, 0, sd.Count);
            }

            // 返回当前元素
            public Object Current { get { ValidateIndex(); return items[index]; } }

            // 返回当前字典实体
            public DictionaryEntry Entry
            {
                get { return (DictionaryEntry)Current; }
            }

            // 返回键值
            public Object Key { get { ValidateIndex(); return items[index].Key; } }

            // 返回指定索引的值
            public Object Value { get { ValidateIndex(); return items[index].Value; } }

            // 下一个
            public Boolean MoveNext()
            {
                if (index < items.Length - 1) { index++; return true; }
                return false;
            }

            // 检查枚举索引，如果超出范围则抛出异常。
            private void ValidateIndex()
            {
                if (index < 0 || index >= items.Length)
                    throw new InvalidOperationException("Enumerator is before or after the collection.");
            }

            // 重置索引值以便重新开始枚举遍历
            public void Reset()
            {
                index = -1;
            }
        }
        public IDictionaryEnumerator GetEnumerator()
        {
            //  构造并返回一个枚举子
            return new SimpleDictionaryEnumerator(this);
        }
        #endregion

        #region ICollection 成员
        public bool IsSynchronized { get { return false; } }
        public object SyncRoot { get { throw new NotImplementedException(); } }
        public int Count { get { return ItemsInUse; } }
        public void CopyTo(Array array, int index) { throw new NotImplementedException(); }
        #endregion

        #region IEnumerable 成员
        IEnumerator IEnumerable.GetEnumerator()
        {
            // 构造并返回一个枚举子
            return ((IDictionary)this).GetEnumerator();
        }
        #endregion
    }
}
