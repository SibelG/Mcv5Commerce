using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineECommerceApp.Models
{
    public class Cari
    {
        [Key]
        public int CariID { get; set; }

        [Display(Name = "Cari Name")]
        [StringLength(30)]
        public string CName { get; set; }

        [Display(Name = "Cari LastName")]
        [StringLength(30)]
        public string CLastName { get; set; }

        [Display(Name = "City")]
        [StringLength(13)]
        public string CCity { get; set; }

        [Display(Name = "Password")]
        [StringLength(8)]
        public string CPassword { get; set; }

        [Display(Name = "Mail")]
        [StringLength(50)]
        public string CMail { get; set; }

        [StringLength(16)]
        public string Phone { get; set; }
        public bool Status { get; set; }
        public ICollection<SalesAction> SalesActions { get; set; }
        public ICollection<ShippingDetail> ShippingDetails { get; set; }

    }
}