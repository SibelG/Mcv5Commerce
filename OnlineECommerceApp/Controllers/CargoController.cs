using OnlineECommerceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace OnlineECommerceApp.Controllers
{
    public class CargoController : Controller
    {
        private Context db = new Context();
        // GET: Cargo
        public ActionResult Index()
        {
            return View(db.CargoDetails.ToList());
        }


        public ActionResult Create()
        {
            Random rand = new Random();
            string[] characters = { "A", "B", "C", "D" ,"E", "F", "G", "H", "K"};
            int k1, k2, k3;
            k1 = rand.Next(0, characters.Length);
            k2 = rand.Next(0, characters.Length);
            k3 = rand.Next(0, characters.Length);
            int s1,s2,s3;
            s1 = rand.Next(100, 1000);
            s2 = rand.Next(10, 99);
            s3 = rand.Next(10, 99);
            String code = s1.ToString() + characters[k1] + s2 + characters[k2]+ s3 + characters[k3] ;
            ViewBag.code = code;
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CargoDetail cargoDetail)
        {
            if (ModelState.IsValid)
            {

                db.CargoDetails.Add(cargoDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cargoDetail);
        }
        public ActionResult CargoTracking(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           CargoTracking ct = db.CargoTrackings.Find(id);
            if (ct == null)
            {
                return HttpNotFound();
            }
           
            return View(ct);
        }
    }
}