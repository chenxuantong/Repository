using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDS017.BinarySTreeDemo
{
    /// <summary>
    /// 演示二叉树遍历的例子
    /// </summary>
    class BinaryTreeDemo005
    {
        public BinaryTreeDemo005()
        {
            var bt = new BinaryTree();
            bt.Insert("L", 1);
            bt.Insert("D", 2);
            bt.Insert("C", 3);
            bt.Insert("A", 4);
            bt.Insert("H", 5);
            bt.Insert("F", 6);
            bt.Insert("J", 7);
            bt.Insert("P", 8);
            Console.WriteLine();
            Console.WriteLine(" 树的节点数：{0}", bt.Count());
            Console.WriteLine(" 当前树结构: " + bt.DrawTree() + "\n");

            // 先序遍历
            Console.Write(" 先序遍历：");
            var startWithPreOrder = bt.Search("L");
            bt.TraverseByPreOrder(startWithPreOrder);
            Console.WriteLine();

            // 中序遍历
            Console.Write(" 中序遍历：");
            var startWithMidOrder = bt.Search("L");
            bt.TraverseByMidOrder(startWithMidOrder);
            Console.WriteLine();

            // 后序遍历
            Console.Write(" 后序遍历：");
            var startWithAfterOrder = bt.Search("L");
            bt.TraverseByPostOrder(startWithAfterOrder);
            Console.WriteLine();

            // 深度优先遍历
            Console.Write(" 深度优先：");
            var startWithDepthFirst = bt.Search("L");
            bt.TranverseByDepthFirst(startWithAfterOrder);
            Console.WriteLine();

            // 宽度优先遍历
            Console.Write(" 宽度优先：");
            var startWithWidthFirst = bt.Search("L");
            bt.TranverseByWidthFirst(startWithAfterOrder);
            Console.WriteLine();

            Console.ReadKey();


        }
    }
}
