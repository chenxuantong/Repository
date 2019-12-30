using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDS017.BinarySTreeDemo
{
    /// <summary>
    /// 二叉树的以及相应数据管理处理
    /// </summary>
    public class BinaryTree
    {
        private BinaryTreeNode _Root;     // 根
        private int _Count = 0;

        public BinaryTree()
        {
            this._Root = null;
            this._Count = 0;
        }

        /// <summary>
        /// 根据指定的
        /// </summary>
        /// <param name="p"></param>
        private void _KillTree(ref BinaryTreeNode p)
        {
            if (p != null)
            {
                _KillTree(ref p.LeftNode);
                _KillTree(ref p.RightNode);
                p = null;
            }
        }
        public void Clear()
        {
            _KillTree(ref _Root);
            _Count = 0;
        }

        /// <summary>
        /// 节点个数
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return _Count;
        }

        /// <summary>
        /// 按照节点 Name 值遍历，查询成功返回节点实例，否则返回 null
        /// 查询匹配条件说明：
        ///     1.名字相同，查到目标并立即返回节点实例；
        ///     2.如果遍历到的节点的名称排序值大于待查节点的名称（如 E 大于 B），则将当前节点的右节点作为
        ///       下一个节点遍历比较；
        ///     3.如果遍历到的节点的名称排序值小于于待查节点的名称，则将当前节点的左节点作为下一个节点遍历
        ///       比较； 
        ///     4.使用 while 循环直至遍历的节点为空，如果未能执行 1，则返回 null。
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public BinaryTreeNode Search(string nodeName)
        {
            var reasultNode = _Root;    // 从根节点开始检索
            int cmp;                    // 匹配因子

            while (reasultNode != null)
            {
                cmp = String.Compare(nodeName, reasultNode.Name);
                if (cmp == 0)   
                    return reasultNode;    // 查到结果，返回查询结果节点，并退出 while 循环

                if (cmp < 0)
                    reasultNode = reasultNode.LeftNode;    // 将当前节点的左节点作为下一个节点遍历比较
                else
                    reasultNode = reasultNode.RightNode;   // 将当前节点的右节点作为下一个节点遍历比较
            }
            return null;  // 未查到任何结果，返回空值
        }

        /// <summary>
        /// 添加节点，添加节点的约束示例：
        ///     1.节点名称不能重复：添加的节点 node 的名称与父节点 tree 的名称的排序比较值 = 0；
        ///     2.作为左节点，添加的节点 node 的名称与父节点 tree 的名称的排序比较值 = -1；
        ///     3.作为右节点，添加的节点 node 的名称与父节点 tree 的名称的排序比较值 = 1。
        /// 递归实现：
        ///     1.从 _Root 节点开始递归，参见 Insert 方法；
        ///     2.如果 tree 为空，则直接将待添加的节点直接插入在 tree 的位置；
        ///     3.如果 tree 不为空，则根据左右节点原则，将 tree 的左节点或者右节点作为 tree 节点递归；
        ///     4.直至满足 2 结束递归。
        /// </summary>
        /// <param name="node">待添加的节点</param>
        /// <param name="tree">引用变量，以便将待插入的节点插入这里</param>
        private void _Add(BinaryTreeNode node, ref BinaryTreeNode tree)
        {
            if (tree == null)
                tree = node;  // 递归完成时，节点 tree 位置即为为待添加的节点的位置
            else
            {
                var comparison = String.Compare(node.Name, tree.Name);

                if (comparison == 0)  // 限制 Name 的值相同的节点重复加入
                    throw new Exception();

                #region 添加节点
                if (comparison < 0)
                {
                    _Add(node, ref tree.LeftNode);   // 把 tree 的左节点作为待添加的节点位置
                }
                else
                {
                    _Add(node, ref tree.RightNode);  // 把 tree 的左节点作为待添加的节点位置
                } 
                #endregion
            }
        }

        /// <summary>
        /// 插入节点
        /// </summary>
        /// <param name="name">节点名称</param>
        /// <param name="value">节点对象的值</param>
        /// <returns></returns>
        public BinaryTreeNode Insert(string name, double value)
        {
            var node = new BinaryTreeNode(name, value);   // 创建节点
            try
            {
                if (_Root == null)   // 没有根节点，将当前创建的节点作为根节点
                    _Root = node;
                else                 // 添加节点
                    _Add(node, ref _Root);

                _Count++;
                return node;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// 查找给定节点名称的节点的父结点
        /// </summary>
        /// <param name="name">指定的节点的名称</param>
        /// <param name="parent">引用参数，指定节点的父节点</param>
        /// <returns></returns>
        private BinaryTreeNode _FindParent(string nodeName, ref BinaryTreeNode parentNode)
        {
            var resultNode = _Root;   // 目标几点，从根节点开始处理
            parentNode = null;        // 将传入的引用参数置空
            int cmp;                  // 用于存放比较传入的节点名 name 与 np 节点名称结果的变量

            while (resultNode != null)
            {
                cmp = String.Compare(nodeName, resultNode.Name);

                if (cmp == 0) 
                    return resultNode;  // 条件满足，并退出 while 循环，返回目标节点，结束查询。

                if (cmp < 0) 
                {
                    // 将当前的父节点改为：目标节点，目标节点改为目标节点的左节点
                    parentNode = resultNode;
                    resultNode = resultNode.LeftNode;
                }
                else
                {
                    // 将当前的父节点改为：目标节点，目标节点改为目标节点的右节点
                    parentNode = resultNode;
                    resultNode = resultNode.RightNode;
                }
            }
            return null;  // 未查到任何结果，返回空值
        }

        /// <summary>
        /// 查找指定节点的继任节点，这里遵循使用右节点作为继任节点，继任节点的要求：
        ///   1.选择待删除节点的右子节点开始选；
        ///   2.使用 while 获取从开始检查节点的左子节点，直到这个子节点不存在子节点位置
        /// </summary>
        /// <param name="startNode">待查节点，其实就是检查开始的节点</param>
        /// <param name="parent">继任节点的父节点</param>
        /// <returns>返回继任节点</returns>
        public BinaryTreeNode FindSuccessor(BinaryTreeNode startNode, ref BinaryTreeNode parent)
        {
            parent = startNode;
            startNode = startNode.RightNode;
            while (startNode.LeftNode != null)
            {
                parent = startNode;
                startNode = startNode.LeftNode;
            }
            return startNode;
        }

        /// <summary>
        /// 删除节点需要考虑三种场景：
        ///     1.删除叶子；
        ///     2.删除只包含单一子节点的节点；
        ///     3.删除包含两个子节点的节点。
        /// </summary>
        /// <param name="nameOfNodeToBeDeleted">待删除的节点的名称</param>
        public void Delete(string nameOfNodeToBeDeleted)
        {
            BinaryTreeNode parent = null;   // 待删除节点的父节点
            var nodeToDelete = _FindParent(nameOfNodeToBeDeleted, ref parent);  // 检索待删除的节点和它的父节点

            if (nodeToDelete == null)
                throw new Exception("无法删除节点: " + nameOfNodeToBeDeleted.ToString());

            #region 删除叶子节点
            // 如果只有一个简单的叶子（没有任何子节点），只需将其父节点相关的指向关系置空即可。
            if ((nodeToDelete.LeftNode == null) && (nodeToDelete.RightNode == null))
            {
                // 待删除结点为根节点时
                if (parent == null)
                {
                    _Root = null;
                    return;
                }

                // 检查待删除节点是父节点的左或者右节点，将左节点或者右节点置空。
                if (parent.LeftNode == nodeToDelete)
                    parent.LeftNode = null;
                else
                    parent.RightNode = null;
                _Count--;
                return;
            }
            #endregion

            #region 删除单一子节点的节点（只有右节点）
            // 待删除节点有一个子节点是空的（只有右节点），此时需要删除后将其子节点上移。
            if (nodeToDelete.LeftNode == null)
            {
                // 待删除结点为根节点时
                if (parent == null)
                {
                    _Root = nodeToDelete.RightNode;
                    return;
                }

                // 根据待删除节点在其父节点的位置（左/右），将其子节点替换进来
                if (parent.LeftNode == nodeToDelete)
                    parent.LeftNode = nodeToDelete.RightNode;
                else
                    parent.RightNode = nodeToDelete.RightNode;

                nodeToDelete = null; // 清除待删除的节点
                _Count--;
                return;
            }
            #endregion

            #region 删除单一子节点的节点（只有左节点）
            // 待删除节点有一个子节点是空的（只有右节点），此时需要删除后将其子节点上移。
            if (nodeToDelete.RightNode == null)
            {
                // 待删除结点为根节点时
                if (parent == null)
                {
                    _Root = nodeToDelete.LeftNode;
                    return;
                }

                // 根据待删除节点在其父节点的位置（左/右），将其子节点替换进来
                if (parent.LeftNode == nodeToDelete)
                    parent.LeftNode = nodeToDelete.LeftNode;
                else
                    parent.RightNode = nodeToDelete.LeftNode;

                nodeToDelete = null; // 清除待删除的节点
                _Count--;
                return;
            }
            #endregion

            #region 删除具有两个子节点的节点
            // 待删除结点有两个子节点，此时需要考虑一个继任节点来替换被删除的节点，继任的节点将原来于其他节点的关系
            // 调整为与被删除节点的角色，重新建立关系。
            var successor = FindSuccessor(nodeToDelete, ref parent);        // 获取继任节点
            var tmp = new BinaryTreeNode(successor.Name, successor.Value);  // 构建继任节点的副本

            // 检查继任节点的父节点与其的关系，如果存在关系，则清理掉。
            if (parent.LeftNode == successor)
                parent.LeftNode = null;
            else
                parent.RightNode = null;

            // 将继任节点的值拷贝的被删除的节点（即替换被删除的节点）
            nodeToDelete.Name = tmp.Name;
            nodeToDelete.Value = tmp.Value;

            _Count--; 
            #endregion
        }

        /// <summary>
        /// 使用递归方式，从指定的节点出发，遍历之下的所有节点，并将树结构用字符表达式表达出来。
        /// </summary>
        /// <param name="node">指定的节点</param>
        /// <returns>指定节点下的全部结构的字符表达式</returns>
        private string _DrawNode(BinaryTreeNode node)
        {
            if (node == null)
                return "空";

            if ((node.LeftNode == null) && (node.RightNode == null))
                return node.Name;
            if ((node.LeftNode != null) && (node.RightNode == null))
                return node.Name + "(" + _DrawNode(node.LeftNode) + ", _)";

            if ((node.RightNode != null) && (node.LeftNode == null))
                return node.Name + "(_, " + _DrawNode(node.RightNode) + ")";

            return node.Name + "(" + _DrawNode(node.LeftNode) + ", " + _DrawNode(node.RightNode) + ")";
        }

        /// <summary>
        /// 打印树结构
        /// </summary>
        /// <returns></returns>
        public string DrawTree()
        {
            return _DrawNode(_Root);
        }

        /// <summary>
        /// 先序遍历：
        ///   1.访问遍历到达的结点；
        ///   2.遍历左子树；
        ///   3.遍历右子树。
        /// </summary>
        /// <param name="startNode">起始节点，根节点</param>
        public void TraverseByPreOrder(BinaryTreeNode startNode)
        {
            if (startNode != null)
            {
                Console.Write(" {0} ",startNode.Name);  // 遍历到达节点，需要的话在这里处理
                TraverseByPreOrder(startNode.LeftNode);
                TraverseByPreOrder(startNode.RightNode);
            }
        }

        /// <summary>
        /// 中序遍历：
        ///   1.遍历左子树；
        ///   2.访问遍历到达的结点；
        ///   3.遍历右子树。
        /// </summary>
        /// <param name="startNode"></param>
        public void TraverseByMidOrder(BinaryTreeNode startNode)
        {
            if (startNode != null)
            {
                TraverseByMidOrder(startNode.LeftNode);
                Console.Write(" {0} ", startNode.Name);  // 遍历到达节点，需要的话在这里处理
                TraverseByMidOrder(startNode.RightNode);
            }

        }

        /// <summary>
        /// 后序遍历：
        ///   1.遍历左子树；
        ///   2.遍历右子树；
        ///   3.访问遍历到达的节点;
        /// </summary>
        /// <param name="startNode"></param>
        public void TraverseByPostOrder(BinaryTreeNode startNode)
        {
            if (startNode != null)
            {
                TraverseByPostOrder(startNode.LeftNode);
                TraverseByPostOrder(startNode.RightNode);
                Console.Write(" {0} ", startNode.Name);  // 遍历到达节点，需要的话在这里处理
            }
        }

        /// <summary>
        /// 层次遍历之深度优先
        ///   先访问根结点，然后遍历左子树接着是遍历右子树，
        ///   利用堆栈的先进后出的特点，现将右子树压栈，再将左子树压栈，这样左子树就位于栈顶，
        ///   可以保证结点的左子树先与右子树被遍历。
        /// </summary>
        /// <param name="startNode"></param>
        public void TranverseByDepthFirst(BinaryTreeNode startNode)
        {
            var stack = new Stack<BinaryTreeNode>();
            stack.Push(startNode);

            while (stack.Count > 0)
            {
                var bt = stack.Pop();
                Console.Write(" {0} ", bt.Name);  // 遍历到达节点，需要的话在这里处理

                if (bt.RightNode != null)
                    stack.Push(bt.RightNode);

                if (bt.LeftNode != null)
                    stack.Push(bt.LeftNode);
            }
        }

        /// <summary>
        /// 层次遍历广度优先，横向优先搜索，是从根结点开始沿着树的宽度搜索遍历
        /// </summary>
        /// <param name="startNode"></param>
        public void TranverseByWidthFirst(BinaryTreeNode startNode)
        {
            var queue = new Queue<BinaryTreeNode>();
            queue.Enqueue(startNode);

            while (queue.Count > 0)
            {
                var bt = queue.Dequeue();
                Console.Write(" {0} ", bt.Name);  // 遍历到达节点，需要的话在这里处理

                if (bt.LeftNode != null)
                    queue.Enqueue(bt.LeftNode);
                if (bt.RightNode != null)
                    queue.Enqueue(bt.RightNode);
            }
        }

    }
}
