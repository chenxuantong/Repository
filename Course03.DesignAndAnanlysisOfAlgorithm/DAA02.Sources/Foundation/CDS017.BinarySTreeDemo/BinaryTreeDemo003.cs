using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDS017.BinarySTreeDemo
{
    class BinaryTreeDemo003
    {
        public BinaryTreeDemo003()
        {
            var bt = new BinaryTree();
            bt.Insert("A", 100);
            bt.Insert("B", 100);
            bt.Insert("C", 100);
            bt.Insert("D", 100);
            bt.Insert("E", 100);
            bt.Insert("F", 100);
            bt.Insert("G", 100);

            Console.WriteLine();
            Console.WriteLine(" 树的节点数：{0}", bt.Count());
            Console.WriteLine(" 当前树结构: " + bt.DrawTree() + "\n");
            Console.ReadKey();

        }
    }
}
