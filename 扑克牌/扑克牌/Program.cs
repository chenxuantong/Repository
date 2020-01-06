using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 扑克牌
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> poke = new List<int>();
            for (int i = 1; i <= 52; i++)
            {
                poke.Add(i);
            }
            List<int> newPoke = ListRandom(poke);
            int[] user1 = new int[13];
            int[] user2 = new int[13];
            int[] user3 = new int[13];
            int[] user4 = new int[13];
            for (int i = 0; i < 13; i++)
            {
                user1[i] = poke[0];
                poke.Remove(poke[0]);
            }
            for (int i = 0; i < 13; i++)
            {
                user2[i] = poke[0];
                poke.Remove(poke[0]);
            }
            for (int i = 0; i < 13; i++)
            {
                user3[i] = poke[0];
                poke.Remove(poke[0]);
            }
            for (int i = 0; i < 13; i++)
            {
                user4[i] = poke[0];
                poke.Remove(poke[0]);
            }
            Console.WriteLine("用户一的牌：");
            Console.WriteLine("");
            var u1 = user1.OrderByDescending(i => i);
            foreach (int x in u1)
            {
                string name = Name(x);
                Console.Write(name + "  ,");
            }
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("用户二的牌：");
            Console.WriteLine("");
            var u2 = user2.OrderByDescending(i => i);
            foreach (int x in u2)
            {
                string name = Name(x);
                Console.Write(name + "  ,");
            }
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("用户三的牌：");
            Console.WriteLine("");
            var u3 = user3.OrderByDescending(i => i);
            foreach (int x in u3)
            {
                string name = Name(x);
                Console.Write(name + "  ,");
            }
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("用户四的牌：");
            Console.WriteLine("");
            var u4 = user4.OrderByDescending(i => i);
            foreach (int x in u4)
            {
                string name = Name(x);
                Console.Write(name + "  ,");
            }
        }
        public static string Name(int id)
        {
            string Name = "";
            switch (id)
            {
                case 1: Name = "方块3"; break;
                case 2: Name = "梅花3"; break;
                case 3: Name = "红桃3"; break;
                case 4: Name = "黑桃3"; break;
                case 5: Name = "方块4"; break;
                case 6: Name = "梅花4"; break;
                case 7: Name = "红桃4"; break;
                case 8: Name = "黑桃4"; break;
                case 9: Name = "方块5"; break;
                case 10: Name = "梅花5"; break;
                case 11: Name = "红桃5"; break;
                case 12: Name = "黑桃5"; break;
                case 13: Name = "方块6"; break;
                case 14: Name = "梅花6"; break;
                case 15: Name = "红桃6"; break;
                case 16: Name = "黑桃6"; break;
                case 17: Name = "方块7"; break;
                case 18: Name = "梅花7"; break;
                case 19: Name = "红桃7"; break;
                case 20: Name = "黑桃7"; break;
                case 21: Name = "方块8"; break;
                case 22: Name = "梅花8"; break;
                case 23: Name = "红桃8"; break;
                case 24: Name = "黑桃8"; break;
                case 25: Name = "方块9"; break;
                case 26: Name = "梅花9"; break;
                case 27: Name = "红桃9"; break;
                case 28: Name = "黑桃9"; break;
                case 29: Name = "方块10"; break;
                case 30: Name = "梅花10"; break;
                case 31: Name = "红桃10"; break;
                case 32: Name = "黑桃10"; break;
                case 33: Name = "方块J"; break;
                case 34: Name = "梅花J"; break;
                case 35: Name = "红桃J"; break;
                case 36: Name = "黑桃J"; break;
                case 37: Name = "方块Q"; break;
                case 38: Name = "梅花Q"; break;
                case 39: Name = "红桃Q"; break;
                case 40: Name = "黑桃Q"; break;
                case 41: Name = "方块K"; break;
                case 42: Name = "梅花K"; break;
                case 43: Name = "红桃K"; break;
                case 44: Name = "黑桃K"; break;
                case 45: Name = "方块A"; break;
                case 46: Name = "梅花A"; break;
                case 47: Name = "红桃A"; break;
                case 48: Name = "黑桃A"; break;
                case 49: Name = "方块2"; break;
                case 50: Name = "梅花2"; break;
                case 51: Name = "红桃2"; break;
                case 52: Name = "黑桃2"; break;
            }
            return Name;
        }
        static List<int> ListRandom(List<int> myList)
        {

            Random ran = new Random();
            List<int> newList = new List<int>();
            int index = 0;
            int temp = 0;
            for (int i = 0; i < myList.Count; i++)
            {

                index = ran.Next(0, myList.Count - 1);
                if (index != i)
                {
                    temp = myList[i];
                    myList[i] = myList[index];
                    myList[index] = temp;
                }
            }
            return myList;
        }
    }
    }
}
