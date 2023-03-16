using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineECommerceApp.Models
{
    public class OrderDetailsModel
    {
        public int OrderId { get; set; }
        public string OrderNumber { get; set; }
        public double Total { get; set; }
        public DateTime OrderDate { get; set; }
        public EnumOrderState OrderState { get; set; }

        public string FirstName { get; set; }
        public string AddressTitle { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Neighborhood { get; set; }
        public string Building { get; set; }
        public string PostalCode { get; set; }
        public string ZipCode { get; set; }

        public virtual List<OrderLineModel> Orderlines { get; set; }
    }

    public class OrderLineModel
    {
        public int? ProductId { get; set; }
        public string ProductName { get; set; }
        public string Image { get; set; }

        public int? Quantity { get; set; }
        public double Price { get; set; }

    }
}
