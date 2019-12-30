using System;
using System.Collections;

namespace CDS001.IEnumerableDemo
{
    /// <summary>
    /// 构建一个 IEnumerable 对象，遍历其中的元素
    /// </summary>
    class Program
    {
        static void Main()
        {
            // 使用对象数组方式构建人员集合实例 peopleArray
            Person[] peopleArray = new Person[3] {
                new Person("John", "Smith"),
                new Person("Jim", "Johnson"),
                new Person("Sue", "Rabon"),
            };

            // 使用自定义的 IEnumerable 枚举器类 People 创建人员集合实例 peopleList
            People peopleList = new People(peopleArray);
            foreach (Person p in peopleList)
                Console.WriteLine(p.FirstName + " " + p.LastName);

            Console.ReadKey();
        }
    }

    /// <summary>
    /// 简单的业务对象
    /// </summary>
    public class Person
    {
        public Person(string fName, string lName)
        {
            this.FirstName = fName;
            this.LastName = lName;
        }

        public string FirstName;
        public string LastName;
    }

    /// <summary>
    /// Person 对象的集合：这个类实现一个 IEnumerabale，以便可以使用 foreach 进行遍历
    /// 对于接口 IEnumerabale，必须实现 GetEnumerator 方法 
    /// </summary>
    public class People : IEnumerable
    {
        private Person[] _people;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="pArray"></param>
        public People(Person[] pArray)
        {
            _people = new Person[pArray.Length];

            for (int i = 0; i < pArray.Length; i++)
            {
                _people[i] = pArray[i];
            }
        }

        // 用于实现迭代子获取的 GetEnumerator 方法
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        /// <summary>
        /// 枚举结果
        /// </summary>
        /// <returns></returns>
        public PeopleEnum GetEnumerator()
        {
            return new PeopleEnum(_people);
        }
    }

    /// <summary>
    /// 当需要实现一个可以枚举遍历的对象，需要实现枚举子 IEnumerator.
    /// </summary>
    public class PeopleEnum : IEnumerator
    {
        public Person[] _people;  // 待处理人员数组
        int position = -1;        // 枚举子指针排位时，缺省指向第一个元素，
                                  // 当方法 MoveNext() 被调用的时候，才会指向下一个元素。


        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="list">传入的人员数组</param>
        public PeopleEnum(Person[] list)
        {
            _people = list;
        }

        /// <summary>
        /// 是否存在下一个元素
        /// </summary>
        /// <returns></returns>
        public bool MoveNext()
        {
            position++;
            return (position < _people.Length);
        }

        /// <summary>
        /// 重置下标
        /// </summary>
        public void Reset()
        {
            position = -1;
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        /// <summary>
        /// 获取当前下标的元素
        /// </summary>
        public Person Current
        {
            get
            {
                try
                {
                    return _people[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }

}
