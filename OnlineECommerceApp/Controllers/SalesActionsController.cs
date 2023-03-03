using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineECommerceApp.Models;

namespace OnlineECommerceApp.Controllers
{
    public class SalesActionsController : Controller
    {
        private Context db = new Context();

        // GET: SalesActions
        public ActionResult Index()
        {
            return View(db.SalesActions.ToList());
        }

        // GET: SalesActions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesAction salesAction = db.SalesActions.Find(id);
            if (salesAction == null)
            {
                return HttpNotFound();
            }
            return View(salesAction);
        }

        // GET: SalesActions/Create
        public ActionResult Create()
        {
            List<SelectListItem> deger1 = (from x in db.Products.ToList()
                                           select new SelectListItem
                                           {
                                               Text=x.ProductName,
                                               Value=x.ProductID.ToString()

                                           }).ToList();

            List<SelectListItem> deger2 = (from x in db.Caris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CName + " " + x.CLastName,
                                               Value = x.CariID.ToString()

                                           }).ToList();

            List<SelectListItem> deger3 = (from x in db.Personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PName + " " +x.PLastName,
                                               Value = x.PersonelID.ToString()

                                           }).ToList();

            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            return View();
        }

        // POST: SalesActions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SalesId,Tarih,Amount,Price,TotalPrice")] SalesAction salesAction)
        {
            if (ModelState.IsValid)
            {
                db.SalesActions.Add(salesAction);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(salesAction);
        }

        // GET: SalesActions/Edit/5
        public ActionResult Edit(int? id)
        {
            List<SelectListItem> deger1 = (from x in db.Personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PName+ " " +x.PLastName,
                                               Value = x.PersonelID.ToString()
                                           }).ToList();
            ViewBag.d1 = deger1;
            List<SelectListItem> deger2 = (from x in db.Caris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CName + " " + x.CLastName,
                                               Value = x.CariID.ToString()
                                           }).ToList();
            ViewBag.d2 = deger2;
            List<SelectListItem> deger3 = (from x in db.Products.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.ProductName,
                                               Value = x.ProductID.ToString()
                                           }).ToList();
            ViewBag.d3 = deger3;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesAction salesAction = db.SalesActions.Find(id);
            if (salesAction == null)
            {
                return HttpNotFound();
            }
            return View(salesAction);
        }

        // POST: SalesActions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SalesAction salesAction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salesAction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(salesAction);
        }

        // GET: SalesActions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesAction salesAction = db.SalesActions.Find(id);
            if (salesAction == null)
            {
                return HttpNotFound();
            }
            return View(salesAction);
        }

        // POST: SalesActions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SalesAction salesAction = db.SalesActions.Find(id);
            db.SalesActions.Remove(salesAction);
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
    }
}
