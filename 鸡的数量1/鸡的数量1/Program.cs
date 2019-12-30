using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 鸡的数量1
{
    class Program
    {
        static void Main(string[] args)
        {
            int j, i, k;//i:公鸡 j:母鸡 k:小鸡
            for (j = 0; j <= 20; j++)
            {
                for (i = 0; i <= 33; i++)
                {
                    for (k = 0; k <= 100; k++)
                    {
                        if ((j + i + k == 100) && (j * 5 + i * 3 + k / 3 == 100) && k % 3 == 0)
                        {
                            Console.WriteLine("{0},{1},{2}", j, i, k);
                            Console.Read();
                        }
                    }
                }
            }
        }
    }
}
