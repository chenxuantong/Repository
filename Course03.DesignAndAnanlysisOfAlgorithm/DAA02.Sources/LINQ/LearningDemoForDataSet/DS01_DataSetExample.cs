using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningDemoForDataSet
{
    public static class DS01_DataSetExample
    {
        public static DataSet DemoDS { get; set; }

        /// <summary>
        /// 创建数据集合
        /// </summary>
        public static void Create()
        {
            #region 创建两个数据表
            DataTable table1 = new DataTable("Patients");    // 创建一个数据表，用于存储 病人 数据
            table1.Columns.Add("Name");                      // 添加一个数据列，表示病人姓名
            table1.Columns.Add("Id");                        // 添加一个数据列，表示识别码
            table1.Rows.Add("张文华", 1);
            table1.Rows.Add("李向东", 2);

            DataTable table2 = new DataTable("Medications"); // 创建一个数据表，用于存储 药品 数据
            table2.Columns.Add("Id");                        // 添加一个数据列，表示识别码
            table2.Columns.Add("Medication");                // 添加一个数据列，表示药品名称
            table2.Rows.Add(1, "氨酰心安");
            table2.Rows.Add(2, "阿莫西林");
            #endregion

            // 创建数据集合，将两个数据表添加到数据集合中
            DemoDS = new DataSet("Hospital");
            DemoDS.Tables.Add(table1);
            DemoDS.Tables.Add(table2);
        }

        /// <summary>
        /// 将数据集合结构与内容转换成 XML
        /// </summary>
        public static void VisualizeDataSetXml()
        {
            Console.WriteLine(DemoDS.GetXml());
        }

        /// <summary>
        /// 提取数据集合的 XML 结构 Schema
        /// </summary>
        public static void VisualizeDataSetXmlSchema()
        {
            Console.WriteLine(DemoDS.GetXmlSchema());
        }

        /// <summary>
        /// 数据表的一些简单信息
        /// </summary>
        public static void TableInformation()
        {
            // 遍历数据集合中的数据表
            DataTableCollection collection = DemoDS.Tables;
            for (int i = 0; i < collection.Count; i++)
            {
                DataTable table = collection[i];
                Console.WriteLine("{0}: {1}", i, table.TableName);
            }

            // 第一个表的表名
            Console.WriteLine("x: {0}", DemoDS.Tables[0].TableName);

            // Medications 表的行数
            Console.WriteLine("y: {0}", DemoDS.Tables["Medications"].Rows.Count);
        }

        /// <summary>
        /// 新建数据表并添加到数据集合中
        /// </summary>
        public static void CreateTableAndAddToDataSet()
        {
            DataTable table = new DataTable("Prescription");  // 创建一个处方表
            table.Columns.Add("Dosage", typeof(int));         // 添加一个整型数的数据列，表示剂量
            table.Columns.Add("Drug", typeof(string));        // 添加一个字符串类型的数据列，表示药品
            table.Columns.Add("Patient", typeof(string));     // 添加一个字符串类型数据列，表示病人
            table.Columns.Add("Date", typeof(DateTime));      // 添加一个日期类型的数据列，表示处方日期

            table.Rows.Add(25, "Indocin", "David", DateTime.Now);
            table.Rows.Add(50, "Enebrel", "Sam", DateTime.Now);
            table.Rows.Add(10, "Hydralazine", "Christoff", DateTime.Now);
            table.Rows.Add(21, "Combivent", "Janet", DateTime.Now);
            table.Rows.Add(100, "Dilantin", "Melanie", DateTime.Now);

            DemoDS.Tables.Add(table);
        }

        
    }
}
