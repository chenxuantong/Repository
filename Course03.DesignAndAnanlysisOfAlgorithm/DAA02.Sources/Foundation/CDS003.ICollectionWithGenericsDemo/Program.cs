using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDS003.ICollectionWithGenericsDemo
{
    /// <summary>
    /// 通过实现 ICollection<T> 接口来创建一个定制类盒子（Box）对象的集合以及一些处理方法；
    /// 相等性：长宽高都相等的情况下是同一个盒子/体积相等的情况下是一个盒子；
    /// 存在性：在 BoxCollection 类实现 Contains 方法，用于检查某个尺寸的盒子是否在集合中。
    /// </summary>
    class Program
    {
        static void Main()
        {
            // 定义一个盒子的集合，并向其中添加一下盒子对象
            var bxList = new BoxCollection();
            bxList.Add(new Box(10, 4, 6));
            bxList.Add(new Box(4, 6, 10));
            bxList.Add(new Box(6, 10, 4));
            bxList.Add(new Box(12, 8, 10));

            // 相同维度的盒子不允许加入
            bxList.Add(new Box(10, 4, 6));

            // 检查移除盒子的方法
            Display(bxList);
            Console.WriteLine("移除 6x10x4");
            bxList.Remove(new Box(6, 10, 4));
            Display(bxList);
            // 移除的另外一些实现
            bxList.Remove(bxList[0]);
            bxList.Remove(bxList.FirstOrDefault(x => x.Length == 6));
            Display(bxList);

            // 检查包含盒子的方法，该方法使用长宽高直接进行比较
            var BoxCheck = new Box(8, 12, 10);
            Console.WriteLine("按照长宽高三维符合性条件，盒子{0}x{1}x{2}结果： {3}",
                BoxCheck.Height.ToString(), BoxCheck.Length.ToString(),
                BoxCheck.Width.ToString(), bxList.Contains(BoxCheck).ToString());

            // 检查重载的 Contains 方法，该方法使用体积来做比较
            Console.WriteLine("按照体积符合性条件，盒子{0}x{1}x{2}结果： {3}",
                BoxCheck.Height.ToString(), BoxCheck.Length.ToString(),
                BoxCheck.Width.ToString(), bxList.Contains(BoxCheck,
                new BoxSameVolume()).ToString());

            Console.ReadKey();
        }

        public static void Display(BoxCollection bxList)
        {
            Console.WriteLine("\n高\t长\t宽\t哈希码");
            foreach (Box bx in bxList)
            {
                Console.WriteLine("{0}\t{1}\t{2}\t{3}",
                    bx.Height.ToString(), bx.Length.ToString(),
                    bx.Width.ToString(), bx.GetHashCode().ToString());
            }

            // 直接使用枚举子便利处理的结果
            //IEnumerator enumerator = bxList.GetEnumerator();
            //Console.WriteLine("\n高\t长\t宽\t哈希码");
            //while (enumerator.MoveNext())
            //{
            //    var b = (Box)enumerator.Current;
            //    Console.WriteLine("{0}\t{1}\t{2}\t{3}",
            //    b.Height.ToString(), b.Length.ToString(),
            //    b.Width.ToString(), b.GetHashCode().ToString());
            //}

            Console.WriteLine();
        }

    }

}
