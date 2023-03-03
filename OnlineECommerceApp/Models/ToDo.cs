using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineECommerceApp.Models
{
    public class ToDo
    {

        [Key]
        public int ToDoID { get; set; }
        [StringLength(100)]
        public string Title { get; set; }
        public int Time { get; set; }

        public bool Status { get; set; }


    }
}