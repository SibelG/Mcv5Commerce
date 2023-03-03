using OnlineECommerceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebSockets;

namespace OnlineECommerceApp.Controllers
{
    public class GalleryController : Controller
    {
        private Context db = new Context();
        // GET: Gallery
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }
    }
}