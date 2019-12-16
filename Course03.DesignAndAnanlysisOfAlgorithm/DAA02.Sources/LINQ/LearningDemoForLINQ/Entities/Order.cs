using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningDemoForLINQ.Entities
{
    /// <summary>
    /// 订单
    /// </summary>
    public class Order
    {
        public int OrderID { get; set; }         // 订单标识码
        public DateTime OrderDate { get; set; }  // 下单日期
        public decimal Total { get; set; }       // 订单金额

        public Order() { }

        public Order(int orderID, DateTime orderDate, decimal total)
        {
            OrderID = orderID;
            OrderDate = orderDate;
            Total = total;
        }
    }
}
