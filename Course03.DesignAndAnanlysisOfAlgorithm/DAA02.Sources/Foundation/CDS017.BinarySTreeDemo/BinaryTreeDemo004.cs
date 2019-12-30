using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDS017.BinarySTreeDemo
{
    class BinaryTreeDemo004
    {
        public BinaryTreeDemo004()
        {
            #region 创建演示用的二叉树
            var bt = new BinaryTree();
            bt.Insert("50", 50);
            bt.Insert("60", 60);
            bt.Insert("40", 40);
            bt.Insert("30", 30);
            bt.Insert("20", 20);
            bt.Insert("35", 35);
            bt.Insert("45", 45);
            bt.Insert("44", 44);
            bt.Insert("46", 46);
            Console.WriteLine("树的节点数：{0}", bt.Count());
            Console.WriteLine("当前树结构: " + bt.DrawTree() + "\n");
            Console.ReadKey();
            #endregion


            #region 删除节点处理演示
            bt.Delete("40");
            Console.WriteLine("删除节点 40: " + bt.DrawTree());
            Console.ReadKey();
            bt.Delete("45");
            Console.WriteLine("删除节点 45: " + bt.DrawTree());
            Console.ReadKey();
            #endregion

        }
    }
}
