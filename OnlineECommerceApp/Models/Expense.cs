using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineECommerceApp.Models
{
    public class Expense
    {
        [Key]
        public int ExpenseId { get; set; }
        [StringLength(30)]
        public string Description { get; set; }
        public DateTime Tarih { get; set; }
        public decimal Total { get; set; }
    }
}