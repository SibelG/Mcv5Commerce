using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineECommerceApp.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public double Total { get; set; }
        public DateTime OrderDate { get; set; }
        public EnumOrderState OrderState { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AddressTitle { get; set; }

        public string City { get; set; }
        public string Neighborhood { get; set; }
        public string Street { get; set; }
        public string Building { get; set; }
        public string PostalCode { get; set; }
        public string ZipCode { get; set; }

        public int? CariId { get; set; }
        public virtual Cari Cari { get; set; }
        public virtual List<OrderLine> Orderlines { get; set; }


        public List<OrderLine> OrderLines
        {
            get { return Orderlines; }
        }
    }

    public class OrderLine
    {
        [Key]
        public int Id { get; set; }

        public int? OrderId { get; set; }
        public virtual Order Order { get; set; }

        public int? Quantity { get; set; }
        public double Price { get; set; }

        public int? ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}