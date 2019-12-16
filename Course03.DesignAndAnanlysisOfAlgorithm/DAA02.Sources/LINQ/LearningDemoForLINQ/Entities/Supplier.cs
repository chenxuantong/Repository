using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningDemoForLINQ.Entities
{
    /// <summary>
    /// 商品供应商
    /// </summary>
    public class Supplier
    {
        public string SupplierName { get; set; }  // 供应商名称
        public string Address { get; set; }       // 地址
        public string City { get; set; }          // 城市
        public string Country { get; set; }       // 国家
    }
}
