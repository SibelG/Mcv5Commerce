using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineECommerceApp.Models
{
    public class Personel
    {
        [Key]
        public int PersonelID { get; set; }

        [Display(Name = "Personel Name")]
        [StringLength(30)]
        public string PName { get; set; }

        [Display(Name = "Personel LastName")]
        [StringLength(30)]
        public string PLastName { get; set; }

        [Display(Name = "Image")]
        [StringLength(2000)]
        public string PImage { get; set; }
        public ICollection<SalesAction> SalesActions { get; set; }

        public int? DepartmentId { get; set; }
        public virtual Department Department { get; set; }

    }
}