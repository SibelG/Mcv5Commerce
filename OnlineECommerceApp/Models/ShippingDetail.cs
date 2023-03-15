using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineECommerceApp.Models
{
    public class ShippingDetail
    {
        [Key]
        public int ShippingId { get; set; }

        [Required(ErrorMessage = "Please Enter Name Title")]
        public string FirstName { get; set;}

        [Required(ErrorMessage = "Please Enter LastName Title")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please Enter Phone Title")]
        public string Phone { get; set; }

        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter Address Title")]
        public string AddressTitle { get; set; }



        [Required(ErrorMessage = "Please Enter City")]
        public string City { get; set; }
        [Required(ErrorMessage = "Please Enter Neigborhood")]
        public string Neighborhood { get; set; }
        [Required(ErrorMessage = "Please Enter Street")]
        public string Street { get; set; }

        [Required(ErrorMessage = "Please Enter Building")]
        public string Building { get; set; }
        public string PostalCode { get; set; }

        public string ZipCode { get; set; }




    }
}