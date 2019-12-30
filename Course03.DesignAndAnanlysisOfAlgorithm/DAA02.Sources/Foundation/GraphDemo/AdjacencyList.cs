using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDS019.GraphDemo
{
    /// <summary>
    /// 邻接表
    /// </summary>
    /// <typeparam name="T">顶点数据元素类型</typeparam>
    public class AdjacencyList<T>
    {
        List<Vertex<T>> VertexItems; // 图的顶点集合

        /// <summary>
        /// 构造函数
        /// </summary>
        public AdjacencyList() : this(10) { } 

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="capacity">指定顶点个数</param>
        public AdjacencyList(int capacity) 
        {
            VertexItems = new List<Vertex<T>>(capacity);
        }

        /// <summary>
        /// 添加一个顶点，通过向顶点类添加数据元素对象创建顶点，添加规则：
        ///   每个顶点不能包含相同的数据元素对象。
        /// </summary>
        /// <param name="item">顶点数据元素类型</param>
        public void AddVertex(T item) 
        {   
            if (Contains(item)) // 不允许插入重复数据对象
            {
                throw new ArgumentException("插入了重复顶点数据对象，顶点创建失败！");
            }
            VertexItems.Add(new Vertex<T>(item));
        }

        /// <summary>
        /// 添加一个无向边
        /// </summary>
        /// <param name="from">起始顶点的数据元素对象</param>
        /// <param name="to">到达顶点的数据元素对象</param>
        public void AddEdge(T from, T to)
        {
            Vertex<T> fromVer = _Find(from); // 检索起始顶点
            if (fromVer == null)
            {
                throw new ArgumentException("起始顶点并不存在！");
            }

            Vertex<T> toVer = _Find(to); // 找到结束顶点
            if (toVer == null)
            {
                throw new ArgumentException("到达顶点并不存在！");
            }
            
            // 无向边的两个顶点都需记录边信息
            _AddDirectedEdge(fromVer, toVer);
            _AddDirectedEdge(toVer, fromVer);

        }

        /// <summary>
        /// 深度优先遍历：
        ///   假定以图中某个顶点Vi为出发点，首先访问出发点，然后选择一个Vi的未访问过的邻接点 Vj，
        ///   以Vj为新的出发点继续进行深度优先搜索，直至图中所有顶点都被访问过。显然，这是一个递
        ///   归的搜索过程。
        /// </summary>
        /// <param name="startVertex">遍历起始顶点</param>
        public void DepthFirstTraverse(Vertex<T> startVertex)
        {
            startVertex.HasVisited = true;               // 将访问标志设为true
            Console.Write(startVertex.DataObject + " "); // 访问到达处理
            Node node = startVertex.FirstEdge;

            while (node != null) //访问此顶点的所有邻接点
            {   
                if (!node.Adjvex.HasVisited) // 如果邻接点未被访问，则递归访问它的边
                {
                    DepthFirstTraverse(node.Adjvex); 
                }
                node = node.Next; //访问下一个邻接点
            }
        }

        /// <summary>
        /// 宽度优先遍历：
        ///   它从图的某一顶点Vi出发，访问此顶点后，依次访问Vi的各个未曾访问过的邻接点，然后分别
        ///   从这些邻接点出发，直至图中所有已有已被访问的顶点的邻接点都被访问到。
        /// </summary>
        /// <param name="startVertex"></param>
        public void WidthFirstTraverse(Vertex<T> startVertex)
        {
            Queue<Vertex<T>> queue = new Queue<Vertex<T>>();
            Console.Write(startVertex.DataObject + " "); // 访问到达处理
            startVertex.HasVisited = true;               // 将访问标志设为true
            queue.Enqueue(startVertex);                  // 进队

            while (queue.Count > 0)                      // 只要队不为空就循环
            {
                Vertex<T> w = queue.Dequeue();
                Node node = w.FirstEdge;
                while (node != null) //访问此顶点的所有邻接点
                {   
                    if (!node.Adjvex.HasVisited) // 如果邻接点未被访问，则递归访问它的边
                    {
                        Console.Write(node.Adjvex.DataObject + " "); // 访问到达处理
                        node.Adjvex.HasVisited = true;               // 将访问标志设为true
                        queue.Enqueue(node.Adjvex);                  // 进队
                    }
                    node = node.Next; // 访问下一个邻接点
                }
            }
        }

        /// <summary>
        /// 检查顶点集合中是否包含有指定的数据元素对象
        /// </summary>
        /// <param name="item"></param>
        /// <returns>包含返回 true，否则返回 false</returns>
        public bool Contains(T item) 
        {
            foreach (Vertex<T> v in VertexItems)
            {
                if (v.DataObject.Equals(item))
                {
                    return true;
                }
            }
            return false;
        }

        public Vertex<T> GetVertex(T item)
        {
            return _Find(item);
        }

        /// <summary>
        /// 初始化顶点是否被访问过的状态
        /// </summary>
        public void InitVisited()
        {
            foreach (Vertex<T> v in VertexItems)
            {
                v.HasVisited = false; // 全部置为false
            }
        }

        /// <summary>
        /// 重载 ToString()，便于一些有用的用途
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string s = string.Empty;
            foreach (Vertex<T> v in VertexItems)
            {
                s += " " + v.DataObject.ToString() + ":";
                if (v.FirstEdge != null)
                {
                    Node tmp = v.FirstEdge;
                    while (tmp != null)
                    {
                        s += tmp.Adjvex.DataObject.ToString();
                        tmp = tmp.Next;
                    }
                }
                s += "\r\n";
            }
            return s;
        }

        /// <summary>
        /// 根据指定的顶点数据元素对象，获取相应的顶点
        /// </summary>
        /// <param name="item">指定的顶点数据元素</param>
        /// <returns></returns>
        private Vertex<T> _Find(T item)
        {
            foreach (Vertex<T> v in VertexItems)
            {
                if (v.DataObject.Equals(item))
                {
                    return v;
                }
            }
            return null;
        }
        
        /// <summary>
        /// 根据起始顶点和到达顶点添加一条有向边
        /// </summary>
        /// <param name="fromVer">起始顶点</param>
        /// <param name="toVer">到达顶点</param>
        private void _AddDirectedEdge(Vertex<T> fromVer, Vertex<T> toVer)
        {
            if (fromVer.FirstEdge == null) // 无邻接点时
            {
                fromVer.FirstEdge = new Node(toVer);
            }
            else
            {
                Node tmp, node = fromVer.FirstEdge;
                do
                {   // 检查是否添加了重复边
                    if (node.Adjvex.DataObject.Equals(toVer.DataObject))
                    {
                        throw new ArgumentException("添加了重复的边！");
                    }
                    tmp = node;
                    node = node.Next;
                } while (node != null);

                tmp.Next = new Node(toVer); // 添加到链表未尾
            }
        }


        /// <summary>
        /// 普通的表结点
        /// </summary>
        public class Node
        {
            public Vertex<T> Adjvex; // 归属的顶点
            public Node Next;        // 后置邻接点

            /// <summary>
            /// 构造函数
            /// </summary>
            /// <param name="value">顶点对象</param>
            public Node(Vertex<T> value)
            {
                Adjvex = value;
            }
        }

        /// <summary>
        /// 顶点：表头节点定义
        /// </summary>
        /// <typeparam name="TValue">顶点元素数据元素对象的类型</typeparam>
        public class Vertex<TValue>
        {
            public TValue DataObject;   // 顶点数据元素对象
            public Node FirstEdge;      // 邻接点链表头指针
            public Boolean HasVisited;  // 是否被访问过的标志,遍历时使用

            /// <summary>
            /// 构造函数
            /// </summary>
            /// <param name="value">顶点数据元素对象</param>
            public Vertex(TValue value)
            {
                DataObject = value;
            }
        }
    }
}
