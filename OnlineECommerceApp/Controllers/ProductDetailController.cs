using OnlineECommerceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineECommerceApp.Controllers
{
    public class ProductDetailController : Controller
    {
        private Context db = new Context();
        Class1 cs =new Class1();
        // GET: ProductDetail
        public ActionResult Index()
        {
            cs.Value1= db.Products.Where(x => x.ProductID == 1).ToList();
            cs.Value2= db.Details.Where(y => y.DetailId == 1).ToList();
            return View(cs);
        }
    }
}