using OnlineECommerceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineECommerceApp.Controllers
{
    public class CariPanelController : Controller
    {
        private Context db = new Context();

        // GET: CariPanel
        [Authorize]//only the authorized person
        public ActionResult Index()
        {
            var mail = (string)Session["CMail"];
            var values = db.Caris.FirstOrDefault(x => x.CMail == mail);
            ViewBag.m_mail = mail;
            return View(values);
        }
        public ActionResult MyOrders()
        {
            var mail = (string)Session["CMail"];
            var id= db.Caris.Where(x=>x.CMail == mail.ToString()).Select(y=>y.CariID).FirstOrDefault();
            var values = db.SalesActions.Where(x => x.CariId == id).ToList();
            return View(values);
        }
    }
}