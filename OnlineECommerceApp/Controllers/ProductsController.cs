using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using OnlineECommerceApp.Models;

namespace OnlineECommerceApp.Controllers
{
    public class ProductsController : Controller
    {
        private Context db = new Context();

        // GET: Products
        public ActionResult Index(string p)
        {
            var products = from x in db.Products select x;
            if (!string.IsNullOrEmpty(p))
            {
                products = products.Where(y => y.ProductName.Contains(p));
            }
            return View(products.ToList());
            
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
        [HttpGet]
        // GET: Products/Create
        public ActionResult Create()
        {
            List<SelectListItem> deger1 = (from x in db.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()
                                           }).ToList();
            ViewBag.d1 = deger1;
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            List<SelectListItem> deger2 = (from x in db.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()
                                           }).ToList();
            ViewBag.d2 = deger2;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            product.Status = false;
            //db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public ActionResult ProductList()
        {
            var values=db.Products.ToList();
            return View(values);

        }
        public ActionResult MakeSales(int? id)
        {
            List<SelectListItem> deger1 = (from x in db.Personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PName + " " + x.PLastName,
                                               Value = x.PersonelID.ToString()

                                           }).ToList();

            ViewBag.dgr1 = deger1;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
          
            ViewBag.dgr2 = product.ProductID;
            ViewBag.dgr3 = product.SalesPrice;
            return View();
        }
        [HttpPost]
        public ActionResult MakeSales(SalesAction salesAction)
        {
            if (ModelState.IsValid)
            {
                salesAction.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
                db.SalesActions.Add(salesAction);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(salesAction);
        }
    }
}
