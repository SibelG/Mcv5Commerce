using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineECommerceApp.Models
{
    public class Department
    {
        [Key]
        public int DepartmentID { get; set; }
        [Display(Name = "Departman Name")]
        [StringLength(30)]
        public  string DepartName { get; set; }
        public bool  Status { get; set; }
        public ICollection<Personel> Personels { get; set; }


    }
}