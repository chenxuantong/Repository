using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDS017.BinarySTreeDemo
{
    /// <summary>
    /// 二叉树构造与数据处理算法演示
    /// </summary>
    class Program
    {

        static void Main(string[] args)
        {
            // 树 D(B(A, C), F(E, G))
            //var demo01 = new BinaryTreeDemo001();

            // 树 B(A, D(C, G(F(E, -) ,-)))
            //var demo02 = new BinaryTreeDemo002();

            // 树 A(-, B(-, C(-, D(-, E(-, F(-, G))))))
            //var demo03 = new BinaryTreeDemo003();

            // 树 50(40(30(20, 35), 45(44, 46)), 60)
            //var demo04 = new BinaryTreeDemo004();

            // 树  L(D(C(A, -), H(F, J)), P),遍历算法
            var demo05 = new BinaryTreeDemo005();


        }

    }
}
