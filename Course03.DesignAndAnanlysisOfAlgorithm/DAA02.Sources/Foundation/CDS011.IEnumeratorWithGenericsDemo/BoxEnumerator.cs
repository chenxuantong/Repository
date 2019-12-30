using CDS000.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDS011.IEnumeratorWithGenericsDemo
{
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
            if (++curIndex >= _collection.Count)
            {
                return false;
            }
            else
            {
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
