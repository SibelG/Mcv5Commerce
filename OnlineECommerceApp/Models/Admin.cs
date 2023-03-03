using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineECommerceApp.Models
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }


        [Display(Name ="Admin Name")]
        [StringLength(10)]
        public string AdminName { get; set; }
       
        [StringLength(30)]
        public string Password { get; set; }

      
        [StringLength(1)]
        public string Authority { get; set; }

    }
}