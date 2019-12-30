using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDS009.IEqualityComparerDemo
{
    class Program
    {
        static void Main()
        {
            var boxEqC = new BoxEqualityComparer();

            var boxes = new Dictionary<Box, string>(boxEqC);

            var redBox = new Box(4, 3, 4);
            AddBox(boxes, redBox, "红色");

            var blueBox = new Box(4, 3, 4);
            AddBox(boxes, blueBox, "蓝色");

            var greenBox = new Box(3, 4, 3);
            AddBox(boxes, greenBox, "绿色");

            Console.WriteLine();
            Console.WriteLine("字典集合中包含 {0} 个盒子。", boxes.Count);

            Console.ReadKey();
        }

        private static void AddBox(Dictionary<Box, String> dict, Box box, String name)
        {
            try
            {
                dict.Add(box, name);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("不能添加 {0}: {1}", box, e.Message);
            }
        }

    }
}
