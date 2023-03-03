using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineECommerceApp.Models
{
    public class BillPencil
    {
        [Key]
        public int BillPencilID { get; set; }
        [StringLength(30)]
        public  string Description { get; set; }
      
        public int Amount { get; set; }
        [Display(Name = "Unit Price")]
        public decimal UnitPrice { get; set; }
        [Display(Name = "Total Price")]
        public decimal TotalPrice { get; set; }
        
        public int BillId { get; set; }
        public virtual Bill Bill { get; set; }


    }
}