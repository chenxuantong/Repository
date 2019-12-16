using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningDemoForLINQ.Entities
{
    /// <summary>
    /// 商品
    /// </summary>
    public class Product
    {
        public int ProductID { get; set; }        // 商品标识码
        public string ProductName { get; set; }   // 商品名称
        public string Category { get; set; }      // 商品类别
        public decimal UnitPrice { get; set; }    // 单价
        public int UnitsInStock { get; set; }     // 库存数量
    }
}
