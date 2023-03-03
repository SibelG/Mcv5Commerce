using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineECommerceApp.Models
{
    public class Product
    {
        [Key]
        public  int ProductID { get; set; }

        [Display(Name = "Product Name")]
        [StringLength(30)]
        public  string ProductName { get; set; }

        [StringLength(30)]
        public string Brand { get; set; }
        public short Stock { get; set; }
        [Display(Name = "Purchase  Price")]
        public decimal PurchasePrice { get; set; }
        [Display(Name = "Sales Price")]
        public decimal SalesPrice { get; set; }
        public bool Status { get; set; }
        [Display(Name = "Image")]
        [StringLength(250)]
        public string ProductImage { get; set; }
        public int? CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public ICollection<SalesAction> SalesActions { get; set; } 



    }
}