using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineECommerceApp.Models;

namespace OnlineECommerceApp.Controllers
{
    public class PersonelsController : Controller
    {
        private Context db = new Context();

        // GET: Personels
        public ActionResult Index()
        {
            return View(db.Personels.ToList());
        }

        // GET: Personels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personel personel = db.Personels.Find(id);
            if (personel == null)
            {
                return HttpNotFound();
            }
            return View(personel);
        }

        // GET: Personels/Create
        [HttpGet]
        public ActionResult Create()
        {
            List<SelectListItem> deger1 = (from x in db.Departments.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartName,
                                               Value = x.DepartmentID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;

            return View();
        }

        // POST: Personels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Personel personel)
        {
            if (Request.Files.Count > 0)
            {
                string fileName = Path.GetFileName(Request.Files[0].FileName);
                string pathExstension = Path.GetExtension(Request.Files[0].FileName);
                string path = "~/Image/" + fileName + pathExstension;
                Request.Files[0].SaveAs(Server.MapPath(path));
                personel.PImage = "/Image/" + fileName + pathExstension;
            }
            if (ModelState.IsValid)
            {
                db.Personels.Add(personel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(personel);
        }

        // GET: Personels/Edit/5
        public ActionResult Edit(int? id)
        {
            List<SelectListItem> deger1 = (from x in db.Departments.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartName,
                                               Value = x.DepartmentID.ToString()
                                           }).ToList();
            ViewBag.d1 = deger1;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
          

            Personel personel = db.Personels.Find(id);
            if (personel == null)
            {
                return HttpNotFound();
            }
           
            return View(personel);
        }

        // POST: Personels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Personel personel)
        {
            if (Request.Files.Count > 0)
            {
                string fileName = Path.GetFileName(Request.Files[0].FileName);
                string pathExstension = Path.GetExtension(Request.Files[0].FileName);
                string path = "~/Image/" + fileName + pathExstension;
                Request.Files[0].SaveAs(Server.MapPath(path));
                personel.PImage = "/Image/" + fileName + pathExstension;
            }

            if (ModelState.IsValid)
            {
                db.Entry(personel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View(personel);
        }

        // GET: Personels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personel personel = db.Personels.Find(id);
            if (personel == null)
            {
                return HttpNotFound();
            }
            return View(personel);
        }

        // POST: Personels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Personel personel = db.Personels.Find(id);
            db.Personels.Remove(personel);
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
        public ActionResult PersonelList()
        {
            var personel = db.Personels.ToList();
            return View(personel);
        }
    }
}
