using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineECommerceApp.Models
{
    public class SalesAction
    {
        [Key]
        public int SalesId { get; set; }
        public DateTime Date { get; set; }
        public int Amount { get; set; }
        public decimal? Price { get; set; }
        [Display(Name = "Total Price")]
        public decimal? TotalPrice { get; set; }
        public int? ProductId { get; set; }
        public int? CariId { get; set; }
        public int? PersonelId { get; set; }
        public virtual Product Product { get; set; }
        public virtual Cari Cari { get; set; }
        public virtual Personel Personel { get; set; }
    }
}