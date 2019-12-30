using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDS003.ICollectionWithGenericsDemo
{
    // 定义 BoxCollection 的枚举子(也可以作为 BoxCollection 的内嵌类处理)
    public class BoxEnumerator : IEnumerator<Box>
    {
        private BoxCollection _collection;
        private int curIndex;
        private Box curBox;


        public BoxEnumerator(BoxCollection collection)
        {
            _collection = collection;
            curIndex = -1;
            curBox = default(Box);

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
                curBox = _collection[curIndex];
            }
            return true;
        }

        public void Reset() { curIndex = -1; }

        void IDisposable.Dispose() { }

        public Box Current
        {
            get { return curBox; }
        }

        object IEnumerator.Current
        {
            get { return Current; }
        }

    }
}
