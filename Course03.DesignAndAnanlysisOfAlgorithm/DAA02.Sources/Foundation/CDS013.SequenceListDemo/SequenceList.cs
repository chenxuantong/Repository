using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDS013.SequenceListDemo
{
    /// <summary>
    /// 顺序表应用说明
    /// 源代码来自：http://www.cnblogs.com/lihonglin2016/p/4264839.html
    /// </summary>
    public class SequenceList<T>
    {
        private int maxsize; //顺序表的容量

        public int Maxsize
        {
            get { return maxsize; }
        }
        private T[] data; //数组，用于存储顺序表中的数据元素
        private int last; //指示顺序表最后一个元素的位置下标

        public int Last
        {
            get { return last; }
            set { last = value; }
        }

        // 索引器
        public T this[int index]
        {
            get { return data[index]; }
            set { data[index] = value; }
        }

        public SequenceList(int size)
        {
            data = new T[size];
            maxsize = size;
            last = -1;
        }
        // 顺序表的长度由于数组是 0 基数组，即数组的最小索引为 0，所以，顺序表的长度就是数
        // 组中最后一个元素的索引 last 加 1。
        public int GetLength()
        {
            return last + 1;
        }
        // 清空
        public void Clear()
        {
            last = -1;
        }

        public bool IsEmpty()
        {
            if (last < 0)
            {
                return true;
            }
            return false;
        }
        // 判断顺序表是否已满
        public bool IsFull()
        {
            if (last == maxsize - 1)// 元素下标从0开始
            {
                return true;
            }
            return false;
        }
        // 在顺序表末尾添加新元素
        public void Appled(T item)
        {
            if (!IsFull())
            {
                data[++last] = item;
            }
            else
            {
                Console.WriteLine(" 顺序表已满无法添加 ");
            }
        }
        //在顺序表的第i个数据元素的位置插入一个数据元素
        /*
            算法的时间复杂度分析：顺序表上的插入操作，时间主要消耗在数据的移动
        上，在第i个位置插入一个元素，从ai到an都要向后移动一个位置，共需要移动n-i+1
        个元素，而i的取值范围为 1≤i≤n+1，当i等于 1 时，需要移动的元素个数最多，
        为n个；当i为n+1 时，不需要移动元素。设在第i个位置做插入的概率为pi，则平
        均移动数据元素的次数为n/2。这说明：在顺序表上做插入操作平均需要移动表
        中一半的数据元素，所以，插入操作的时间复杂度为O（n）。
         */
        public void Insert(T item, int i)
        {
            if (i < 1 || i > last + 1)
            {
                Console.WriteLine(" 位置非法 ");
                return;
            }
            if (IsFull())
            {
                Console.WriteLine(" 顺序表已满无法添加 ");
                return;
            }
            if (i == last + 2)// 判断是不是末尾插入
            {
                data[last + 1] = item;
            }
            else
            {
                // i后面的元素往后移
                for (int j = last; j >= i - 1; --j)
                {
                    data[j + 1] = data[j];
                }
                //将新的数据元素插入到第i-1个位置上
                data[i - 1] = item;
            }
            ++last;
        }
        //删除顺序表的第i个数据元素
        /*
         而i的取值范围为 1≤i≤n，当i等于 1 时，需要移动
        的元素个数最多，为n-1 个；当i为n时，不需要移动元素。设在第i个位置做删除
        的概率为pi，则平均移动数据元素的次数为(n-1)/2。这说明在顺序表上做删除操
        作平均需要移动表中一半的数据元素，所以，删除操作的时间复杂度为O（n）
         */
        public T Delete(int i)
        {
            T temp = default(T);// default 为泛型代码中的默认关键字
            if (IsEmpty())
            {
                Console.WriteLine("顺序表为空");
                return temp;
            }
            if (i < 1 || i > last + 1)
            {
                Console.WriteLine(" 位置非法 ");
                return temp;
            }
            if (i == last + 1)
            {
                data[last--] = temp;
            }
            else
            {
                temp = data[i - 1];
                for (int j = i; j <= last; ++j)
                {
                    data[j] = data[j - 1];
                }
            }
            --last;
            return temp;
        }

        //获得顺序表的第i个数据元素
        public T GetElem(int i)
        {
            if (IsEmpty() || (i < 1) || (i > last + 1))
            {
                Console.WriteLine("顺序表为空 or 位置非法!");
                return default(T);
            }
            return data[i - 1];
        }
        //在顺序表中查找值为value的数据元素
        public int Locate(T value)
        {
            if (IsEmpty())
            {
                Console.WriteLine("顺序表为空");
                return -1;
            }
            for (int j = 0; j < last; ++j)
            {
                if (data[j].Equals(value))
                {
                    return j;
                }
            }
            return -1;
        }
        /*
         算法的时间复杂度分析：顺序表中的按值查找的主要运算是比较，比较的次
        数与给定值在表中的位置和表长有关。当给定值与第一个数据元素相等时，比较
        次数为 1；而当给定值与最后一个元素相等时，比较次数为 n。所以，平均比较
        次数为(n+1)/2，时间复杂度为 O（n）
         */
        public void Reverse()
        {
            T temp = default(T);
            int len = GetLength();
            for (int i = 0; i <= len >> 1; ++i)
            {
                temp = data[i];
                data[i] = data[len - i];
                data[len - i] = temp;
            }
        }
    }
}
