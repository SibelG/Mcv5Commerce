using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineECommerceApp.Models
{
    public class CargoDetail
    {
        [Key]
        public int CargoId { get; set; }
        public string Description { get; set; }
        [StringLength(10)]
        public string TrackCode { get; set; }
        public string Personel { get; set; }
        public int? CariId { get; set; }
        public virtual Cari Cari { get; set; }
        public DateTime Date { get; set; }

    }
}