using OnlineECommerceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace OnlineECommerceApp.Controllers
{
    public class StatisticsController : Controller
    {
        private Context db = new Context();
        // GET: Statistics
        public ActionResult Index()
        {
            var d1 = db.Caris.Count().ToString();
            ViewBag.dgr1 = d1;
            var d2 = db.Products.Count().ToString();
            ViewBag.dgr2 = d2;
            var d3 = db.Personels.Count().ToString();
            ViewBag.dgr3 = d3;
            var d4 = db.Categories.Count().ToString();
            ViewBag.dgr4 = d4;
            var d5 = db.Products.Sum(x => x.Stock).ToString();
            ViewBag.dgr5 = d5;
            var d6 = (from x in db.Products select x.Brand).Distinct().Count().ToString();
            ViewBag.dgr6 = d6;
            var d7 = db.Products.Count(x => x.Stock <=20).ToString();
            ViewBag.dgr7 = d7;
            var d8 = (from x in db.Products orderby x.SalesPrice descending select x.ProductName).FirstOrDefault();
            ViewBag.dgr8 = d8;
            var d9 = (from x in db.Products orderby x.SalesPrice ascending select x.ProductName).FirstOrDefault();
            ViewBag.dgr9 = d9;
            var d10 = db.Products.GroupBy(x=>x.Brand).OrderByDescending(z=>z.Count()).Select(y=>y.Key).FirstOrDefault();
            ViewBag.dgr10 = d10;
            var d11 = db.Products.Count(x => x.ProductName == d8).ToString();
            ViewBag.dgr11 = d11;
            var d12 = db.Products.Count(x => x.ProductName == d9).ToString();
            ViewBag.dgr12 = d12;
            var dgr13 = db.Products.Where(u=>u.ProductID==db.SalesActions.GroupBy(x => x.ProductId).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault()).
                Select(k=>k.ProductName).FirstOrDefault();
            ViewBag.dgr13 = dgr13;
            var d14 = db.SalesActions.Sum(x=>x.TotalPrice).ToString();
            ViewBag.dgr14 = d14;
            DateTime now = DateTime.Today;
            var d15 = db.SalesActions.Count(x => x.Date==now).ToString();
            ViewBag.dgr15 = d15;
            var d16 = db.SalesActions.Where(x => x.Date == now).Sum(y => y.TotalPrice).ToString();
            ViewBag.dgr16 = d16;

            return View();
        }
        public ActionResult SimpleTable()
        {
            var query = from x in db.Caris
                        group x by x.CCity into g
                        select new ClassGroup
                        {
                            City = g.Key,
                            Count = g.Count()
                        };
            return View(query.ToList());
        }
        public PartialViewResult PartialOne()
        {
            //var ctg = db.Categories.ToList();
            //return PartialView(ctg);

            var query = from x in db.Products
                        group x by x.Category.CategoryName into g
                        select new Class3
                        {
                            CategoryName = g.Key,
                            Count = g.Count()

                        };

            return PartialView(query.ToList());

        }
        public PartialViewResult PartialTwo()
        {
            var query = from x in db.Personels
                        group x by x.Department.DepartName into g
                        select new ClassGroup2
                        {
                            DepartmanName = g.Key,
                            Count = g.Count()

                        };

            return PartialView(query.ToList());
         }

        public PartialViewResult PartialThree()
        {
            var query = db.Caris.ToList();
            return PartialView(query);
        }
        public PartialViewResult PartialFour()
        {
            var query = db.Products.ToList();
            return PartialView(query);
        }
        public PartialViewResult PartialFive()
        {
            var query = from x in db.Products
                        group x by x.Brand into g
                        select new ClassGroup3
                        {
                            Branch = g.Key,
                            Count = g.Count()

                        };

            return PartialView(query.ToList());
        }
    }
}