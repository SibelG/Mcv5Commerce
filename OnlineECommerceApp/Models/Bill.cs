using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineECommerceApp.Models
{
    public class Bill
    {
        [Key]

        public int BillID { get; set; }
        [StringLength(1)]
        [Display(Name = "Bill Serial No")]
        public string  BillSerialNo { get; set; }
        [StringLength(6)]
        [Display(Name = "Bill Rank No")]
        public string BillRankNo { get; set; }
        public DateTime Date { get; set; }
        [StringLength(30)]
        [Display(Name = "Tax Authority")]
        public string TaxAuthority { get; set; }
        [StringLength(5)]
        public String Time { get; set; }
        [StringLength(30)]
        [Display(Name = "Deliver Person")]
        public string DeliverPerson { get; set; }
        [StringLength(30)]
        [Display(Name = "Receive Person")]
        public string ReceivePerson { get; set; }
        [Display(Name = "Sub Total")]
        public decimal SubTotal { get; set; }

        public ICollection<BillPencil> BillPencils { get; set; }
        public ICollection<Cari> Caris { get; set; }
        public ICollection<Personel> Personels { get; set; }

    }
}