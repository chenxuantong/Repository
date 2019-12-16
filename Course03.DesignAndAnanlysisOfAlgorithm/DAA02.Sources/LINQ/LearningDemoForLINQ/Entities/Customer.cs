using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningDemoForLINQ.Entities
{
    /// <summary>
    /// 客户
    /// </summary>
    public class Customer
    {
        public string CustomerID { get; set; }    // 客户标识
        public string CompanyName { get; set; }   // 公司名称
        public string Address { get; set; }       // 地址
        public string City { get; set; }          // 所在城市
        public string Region { get; set; }        // 归属区县
        public string PostalCode { get; set; }    // 邮政编码
        public string Country { get; set; }       // 国家
        public string Phone { get; set; }         // 电话
        public string Fax { get; set; }           // 传真
        public Order[] Orders { get; set; }       // 客户的订单

        public Customer() { }

        public Customer(string customerID, string companyName)
        {
            CustomerID = customerID;
            CompanyName = companyName;
            Orders = new Order[10];
        }
    }
}
