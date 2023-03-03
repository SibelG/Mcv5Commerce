using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineECommerceApp.Models
{
    public class Detail

    {
        [Key]
        public int DetailId { get; set; }
        [Display(Name = "Product Name")]
        [StringLength(30)]
        public string  ProductName{ get; set; }
        [Display(Name = "Description")]
        [StringLength(2000)]
        public string ProductDesc { get; set; }
    }
}