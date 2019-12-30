using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDS019.GraphDemo
{
    /// <summary>
    /// 图的构建
    /// </summary>
    static class AdjacencyListDemo
    {
        public static AdjacencyList<string> GraphWithAdjacencyList()
        {
            var demoList = new AdjacencyList<string>();

            demoList.AddVertex("A");
            demoList.AddVertex("B");
            demoList.AddVertex("C");
            demoList.AddVertex("D");

            demoList.AddEdge("A", "B");
            demoList.AddEdge("A", "C");
            demoList.AddEdge("A", "D");
            demoList.AddEdge("B", "D");

            return demoList;
        }

    }
}
