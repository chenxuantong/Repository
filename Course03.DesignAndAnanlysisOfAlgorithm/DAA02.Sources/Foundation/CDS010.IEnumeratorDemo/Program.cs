using CDS000.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDS010.IEnumeratorDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Person[] peopleArray = new Person[3]
            {
                new Person { Name="张胜利" },
                new Person { Name="黄付贵" },
                new Person { Name="姜黎黎" }
            };

            People peopleList = new People(peopleArray);
            foreach (Person p in peopleList)
                Console.WriteLine(p.ID + " " + p.Name);

            Console.ReadKey();
        }
    }
}
