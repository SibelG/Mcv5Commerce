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
    public class CarisController : Controller
    {
        private Context db = new Context();

        // GET: Caris
        public ActionResult Index()
        {
            return View(db.Caris.Where(x => x.Status==true).ToList());
        }

        // GET: Caris/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cari cari = db.Caris.Find(id);
            if (cari == null)
            {
                return HttpNotFound();
            }
            return View(cari);
        }

        // GET: Caris/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Caris/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CariID,CName,CLastName,CCity,CMail")] Cari cari)
        {
            if (ModelState.IsValid)
            {
               // cari.Status = true;
                db.Caris.Add(cari);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cari);
        }

        // GET: Caris/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cari cari = db.Caris.Find(id);
            if (cari == null)
            {
                return HttpNotFound();
            }
            return View(cari);
        }

        // POST: Caris/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CariID,CName,CLastName,CCity,CMail")] Cari cari)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cari).State = EntityState.Modified;
                cari.Status = true;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cari);
        }

        // GET: Caris/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cari cari = db.Caris.Find(id);
            if (cari == null)
            {
                return HttpNotFound();
            }
            return View(cari);
        }

        // POST: Caris/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cari cari = db.Caris.Find(id);
            cari.Status = false;
            //db.Caris.Remove(cari);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SalesHistory(int id)
        {
            var values = db.SalesActions.Where(x => x.CariId == id).ToList();
            var cr = db.Caris.Where(x => x.CariID == id).Select(y => y.CName + " " + y.CLastName).FirstOrDefault();
            ViewBag.dgr1 = cr;
            return View(values);
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
