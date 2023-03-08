using OnlineECommerceApp.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace OnlineECommerceApp.Controllers
{
    public class GraphicController : Controller
    {
        Context db = new Context();
        // GET: Graphic
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult IndexTwo()
        {
            var graphic = new Chart(600, 600);
            graphic.AddTitle("Category", "Product Stock Count").AddLegend("Stock")
                .AddSeries("Values", xValue: new[] { "mobilya", "Office", "PC" }, yValues: new[] { 85, 66, 98 }).Write();
            return File(graphic.ToWebImage().GetBytes(), "image/jpeg");


        }
        public ActionResult IndexThree()
        {
            ArrayList xValue = new ArrayList();
            ArrayList yValue = new ArrayList();
            var responses = db.Products.ToList();
            responses.ToList().ForEach(x=>xValue.Add(x.ProductName));
            responses.ToList().ForEach(y=>yValue.Add(y.Stock));
            var graphics = new Chart(width: 800, height: 800)
                .AddTitle("Stocks")
                .AddSeries(chartType: "Pie", name: "Stock", xValue: xValue, yValues: yValue);
            return File(graphics.ToWebImage().GetBytes(), "image/jpeg");


        }
        public ActionResult IndexFour()
        {
            return View();
        }
        public ActionResult VisualizeProductResult()
        {
            return Json(productList(),JsonRequestBehavior.AllowGet);
        }

        public List<Graphic1> productList()
        {
            List<Graphic1> result = new List<Graphic1>();
            result.Add(new Graphic1()
            {
                productName = "pc",
                Stock = 120
            });
            result.Add(new Graphic1()
            {
                productName = "pc",
                Stock = 120
            });
            result.Add(new Graphic1()
            {
                productName = "pc",
                Stock = 120
            });
            return result;


        }
        public ActionResult VisualizeProductResult2()
        {
            return Json(productList(), JsonRequestBehavior.AllowGet);
        }
    }
}