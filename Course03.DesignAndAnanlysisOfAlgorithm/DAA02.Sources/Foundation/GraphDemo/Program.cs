using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDS019.GraphDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var demoList01= AdjacencyListDemo.GraphWithAdjacencyList();
            Console.WriteLine(demoList01);
            Console.ReadKey();

            //demoList01.InitVisited();
            //demoList01.DepthFirstTraverse(demoList01.GetVertex("A"));
            //Console.ReadKey();

            demoList01.InitVisited();
            demoList01.WidthFirstTraverse(demoList01.GetVertex("A"));
            Console.ReadKey();

        }
    }
}
