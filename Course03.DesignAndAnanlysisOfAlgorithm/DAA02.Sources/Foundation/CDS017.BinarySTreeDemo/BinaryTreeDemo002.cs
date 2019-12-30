using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDS017.BinarySTreeDemo
{
    /// <summary>
    /// 这是一个简单的二叉树构建的例子，树结构如下
    ///      B       
    ///   A      D
    ///       C     G
    ///          F
    ///       E
    /// </summary>
    class BinaryTreeDemo002
    {
        public BinaryTreeDemo002()
        {
            var bt = new BinaryTree();
            bt.Insert("B", 100);
            bt.Insert("A", 100);
            bt.Insert("D", 100);
            bt.Insert("C", 100);
            bt.Insert("G", 100);
            bt.Insert("F", 100);
            bt.Insert("E", 100);
            Console.WriteLine();
            Console.WriteLine(" 树的节点数：{0}", bt.Count());
            Console.WriteLine(" 当前树结构: " + bt.DrawTree() + "\n");
            Console.ReadKey();

            // 查找节点
            Console.WriteLine(" 根据名字查找节点示例：{0}","var searchNode = bt.Search(\"F\")");
            var searchNode = bt.Search("F");
            if (searchNode != null)
                Console.WriteLine(" 节点查找成功: 名称-{0}，对象-{1}。",
                    searchNode.Name,searchNode.Value);
            Console.ReadKey();


        }
    }
}
