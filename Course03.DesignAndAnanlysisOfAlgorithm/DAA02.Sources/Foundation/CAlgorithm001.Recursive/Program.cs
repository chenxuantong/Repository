using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAlgorithm001.Recursive
{
    class Program
    {
        static void Main()
        {
            //var a = Fibonacci(1000);
            //var b = FibonacciByRecursive(10);
        }

        /// <summary>
        /// 计算整数 n 的阶乘
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static long Factorial(int n)
        {
            if (n == 0)
                return 1;
            long value = 1;
            for (int i = n; i > 0; i--)
            {
                value *= i;
            }
            return value;
        }

        /// <summary>
        /// 使用递归的方式计算整数 n 的阶乘
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static long FactorialByRecursive(int n)
        {
            if (n == 0)       // 限制递归结束条件
                return 1;
            return n * FactorialByRecursive(n - 1);
        }

        /// <summary>
        /// 获取整数 n 的斐波那契数列的元素个数
        /// 斐波那契数列（Fibonacci sequence），又称黄金分割数列、因数学家列昂纳多·斐波那契（Leonardoda Fibonacci）
        ///     以兔子繁殖为例子而引入，故又称为“兔子数列”，指的是这样一个数列：1、1、2、3、5、8、13、21、34、……在数学上，
        ///     斐波那契数列以如下被以递推的方法定义：F(1)=1，F(2)=1, F(n)=F(n-1)+F(n-2)（n>=3，n∈N*）在现代物理、准晶
        ///     体结构、化学等领域，斐波纳契数列都有直接的应用。
        /// 
        /// 斐波那契以兔子繁殖为例子而引入: 有一对兔子，从出生后第三个月起每个月都生一对兔子，小兔子长到第三个月后每个月又
        ///     生一对兔。假设所有兔子都不死，问每个月的兔子总数为多少？
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static long Fibonacci(int n)
        {
            if (n < 2)
                return n;
            long[] f = new long[n + 1];
            f[0] = 0;
            f[1] = 1;

            for (int i = 2; i <= n; i++)
            {
                f[i] = f[i - 1] + f[i - 2];
            }
            return f[n];
        }

        /// <summary>
        /// 使用递归算法获取整数 n 的斐波那契数列的元素个数
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static long FibonacciByRecursive(int n)
        {
            if (n == 0 || n == 1)    // 收敛条件
                return n;
            Console.Write(n + "\n");
            return FibonacciByRecursive(n - 2) + FibonacciByRecursive(n - 1);
        }

    }
}
