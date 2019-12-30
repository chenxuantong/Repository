using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDS017.BinarySTreeDemo
{
    /// <summary>
    /// 二叉树节点定义
    /// </summary>
    public class BinaryTreeNode
    {
        public string Name;              // 节点名称
        public double Value;             // 节点对象
        public BinaryTreeNode LeftNode;  // 左节点 
        public BinaryTreeNode RightNode; // 右节点

        public BinaryTreeNode(string name, double value)
        {
            this.Name = name;
            this.Value = value;
        }
    }
}
