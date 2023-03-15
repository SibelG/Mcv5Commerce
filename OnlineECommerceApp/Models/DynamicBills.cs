using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineECommerceApp.Models
{
    public class DynamicBills
    {
        public IEnumerable<Bill> value1 { get; set; }
        public IEnumerable<BillPencil> value2 { get; set; } 
    }
}