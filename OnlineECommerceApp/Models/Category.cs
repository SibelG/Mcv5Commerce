using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineECommerceApp.Models
{
    public class Category
    {
        [Key]

        public int CategoryID { get; set; }
        [StringLength(30)]
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }
        public ICollection<Product> Products { get; set; }

    }
}