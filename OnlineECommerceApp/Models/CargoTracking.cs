using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineECommerceApp.Models
{
    public class CargoTracking
    {
        [Key]
        public int CargoTrackId{ get; set; }
        [StringLength(10)]
        public string CargoCode { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }


    }
}