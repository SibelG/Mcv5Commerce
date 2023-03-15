using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace OnlineECommerceApp.Models
{
    public enum EnumOrderState
    {
      
        Created,
        InProgress,
        Completed,
        Canceled,
        PartiallyCanceled,
        Returned,

    }
}