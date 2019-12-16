using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningDemoForDataSet
{
    class Program
    {
        static void Main(string[] args)
        {
            DS01_DataSetExample.Create();
            DS01_DataSetExample.VisualizeDataSetXml();

            Console.ReadKey();

            DS01_DataSetExample.CreateTableAndAddToDataSet();
            var tb = DS01_DataSetExample.DemoDS.Tables[2];
            foreach(DataRow row in tb.Rows)
            {
                Console.WriteLine("病人:{0,-15}药品:{1,-15}剂量：{2,-10}处方日期:{3,-10:yyyy/MM/dd}",
                    row.Field<string>("Patient"),
                    row.Field<string>("Drug"), 
                    row.Field<int>("Dosage"), 
                    row.Field<DateTime>("Date"));
            }
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------");
            Console.ReadKey();

            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------");
            DS01_DataSetExample.VisualizeDataSetXmlSchema();
            Console.ReadKey();

        }
    }
}
