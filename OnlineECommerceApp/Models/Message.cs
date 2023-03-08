using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineECommerceApp.Models
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }
        [StringLength(100)]
        public string MessageTitle { get; set; }
        [StringLength(2000)]
        public string Description { get; set; }
        public string Receiver { get; set; }
        public string Sender { get; set; }
        [Column(TypeName = "Smalldatetime")]
        public DateTime Date { get; set; }


    }
}