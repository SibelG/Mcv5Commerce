using OnlineECommerceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OnlineECommerceApp.Controllers
{
    [Authorize]
    public class CariPanelController : Controller
    {
        private Context db = new Context();

        // GET: CariPanel
        //only the authorized person
        public ActionResult Index()
        {
            int totalCoupon = 0;
            var mail = (string)Session["CMail"];
            var values = db.Caris.FirstOrDefault(x => x.CMail == mail);
            ViewBag.mail = mail;
            var cariId= db.Caris.Where(x=>x.CMail == mail).Select(y=>y.CariID).FirstOrDefault();
            var salesCount = db.SalesActions.Where(x => x.CariId == cariId).Count();
            ViewBag.totalSales = salesCount;
            var totalCount = db.SalesActions.Where(x => x.CariId == cariId).Sum(y => y.TotalPrice);
            ViewBag.totalCount = totalCount;
            if (totalCount < 100)
            {
                totalCoupon=50;
            }
            else if(totalCount >=100 && totalCount < 500)
            {
                totalCoupon = 100;
            }
            else
            {
                totalCoupon = 200;
            }

            ViewBag.totalCoupon = totalCoupon;
            return View(values);
        }
        public ActionResult MyOrders()
        {
            var mail = (string)Session["CMail"];
            var id= db.Caris.Where(x=>x.CMail == mail.ToString()).Select(y=>y.CariID).FirstOrDefault();
            var values = db.SalesActions.Where(x => x.CariId == id).ToList();
            return View(values);
        }
        public ActionResult ReceiveMessage()
        {
            var mail = (string)Session["CMail"];
            var messages = db.Messages.Where(x=>x.Receiver==mail).OrderByDescending(y=>y.MessageId).ToList();
            var receivedCount = db.Messages.Count(x=>x.Receiver == mail).ToString();
            ViewBag.d1 = receivedCount;
            var senderCount = db.Messages.Count(x => x.Sender == mail).ToString();
            ViewBag.d2 = senderCount;

          

            return View(messages);
        }

        [HttpPost]
        public ActionResult ReceiveMessage(int? id)
        {
            Message message = db.Messages.Find(id);
            db.Messages.Remove(message);
            db.SaveChanges();
            return View();
        }
        public ActionResult SenderMessage()
        {
            var mail = (string)Session["CMail"];
            var messages = db.Messages.Where(x => x.Sender == mail).OrderByDescending(y => y.MessageId).ToList();
            var senderCount = db.Messages.Count(x => x.Sender == mail).ToString();
            ViewBag.d2 = senderCount;
            var receivedCount = db.Messages.Count(x => x.Receiver == mail).ToString();
            ViewBag.d1 = receivedCount;
            return View(messages);
        }
        [HttpPost]
        public ActionResult SenderMessage(int? id)
        {
            Message message = db.Messages.Find(id);
            db.Messages.Remove(message);
            db.SaveChanges();
            return View();
        }

        [HttpGet]
        // GET: Products/Create
        public ActionResult NewMessage()
        {
            var mail = (string)Session["CMail"];
            var senderCount = db.Messages.Count(x => x.Sender == mail).ToString();
            ViewBag.d2 = senderCount;
            var receivedCount = db.Messages.Count(x => x.Receiver == mail).ToString();
            ViewBag.d1 = receivedCount;
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       
        public ActionResult NewMessage(Message message)
        {
            if (ModelState.IsValid)
            {
                var mail = (string)Session["CMail"];
                message.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
                message.Sender = mail;
                db.Messages.Add(message);
                db.SaveChanges();
                return View();
            }

            return View(message);
        }

        public ActionResult MessageDetail(int? id)
        {
            var mail = (string)Session["CMail"];
            var senderCount = db.Messages.Count(x => x.Sender == mail).ToString();
            ViewBag.d2 = senderCount;
            var receivedCount = db.Messages.Count(x => x.Receiver == mail).ToString();
            ViewBag.d1 = receivedCount;
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = db.Messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
             
            
            return View(message);

        }

        public ActionResult CargoTracking(string p)
        {
            var k = from x in db.CargoDetails select x;
            k = k.Where(y => y.TrackCode.Contains(p));
           
            return View(k.ToList());
        }
        public ActionResult CargoDetails(int? id)
        {
            var values = db.CargoTrackings.Where(x=>x.CargoTrackId==id).ToList();
            return View(values);
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index","Login");
        }

    }
}