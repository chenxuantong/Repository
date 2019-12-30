using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDS017.BinarySTreeDemo
{
    /// <summary>
    /// 这是一个简单的二叉树构建的例子，树结构如下
    ///     D       
    ///   B    F
    ///  A C  E G   
    /// </summary>
    class BinaryTreeDemo001
    {
        public BinaryTreeDemo001()
        {
            var bt = new BinaryTree();
            bt.Insert("D", 100);
            bt.Insert("B", 100);
            bt.Insert("F", 100);
            bt.Insert("A", 100);
            bt.Insert("C", 100);
            bt.Insert("E", 100);
            bt.Insert("G", 100);

            Console.WriteLine();
            Console.WriteLine(" 树的节点数：{0}", bt.Count());
            Console.WriteLine(" 当前树结构: " + bt.DrawTree() + "\n");
            Console.ReadKey();

            #region 删除叶子节点
            //bt.Insert("X", 100);
            //Console.WriteLine("\n 添加一个节点 X，用于做删除演示");
            //Console.WriteLine(" 当前树结构: " + bt.DrawTree() + "\n");
            //Console.ReadKey();
            //bt.Delete("X");
            //Console.WriteLine(" 删除节点 X，这个节点是叶子节点。");
            //Console.WriteLine(" 当前树结构: " + bt.DrawTree() + "\n");
            //Console.ReadKey();
            #endregion


            #region 删除具有单一子节点的节点
            bt.Insert("X", 100);
            Console.WriteLine("\n 添加一个节点 X，用于做删除演示");
            Console.WriteLine(" 当前树结构: " + bt.DrawTree() + "\n");
            Console.ReadKey();
            bt.Delete("G");
            Console.WriteLine(" 删除节点 G，这个节点带有一个子节点 X。");
            Console.WriteLine(" 当前树结构: " + bt.DrawTree() + "\n");
            Console.ReadKey();
            #endregion

            #region 删除具有两个子节点的节点
            //bt.Insert("X", 100);
            //Console.WriteLine("\n 添加一个节点 X，用于做删除演示");
            //Console.WriteLine(" 当前树结构: " + bt.DrawTree() + "\n");
            //Console.ReadKey();
            //bt.Delete("D");
            //Console.WriteLine(" 删除节点 D，这个节点带有两个子节点 B 和 F。");
            //Console.WriteLine(" 当前树结构: " + bt.DrawTree() + "\n");
            //Console.ReadKey(); 
            #endregion

        }
    }
}
