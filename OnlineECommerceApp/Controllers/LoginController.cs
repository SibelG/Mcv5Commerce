using OnlineECommerceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OnlineECommerceApp.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        Context db = new Context();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult Partial()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult Partial(Cari cari)
        {
            db.Caris.Add(cari);
            db.SaveChanges();
            return PartialView();
        }
        public ActionResult PartialCariLogin()
        {
            return View();

        }
        [HttpPost]
        public ActionResult PartialCariLogin(Cari cari)
        {
            var cariInf = db.Caris.FirstOrDefault(x => x.CMail == cari.CMail && x.CPassword == cari.CPassword);
            if (cariInf!= null)
            {
                FormsAuthentication.SetAuthCookie(cariInf.CMail, false);
                Session["CMail"]=cariInf.CMail.ToString();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index","Login");
            }
            

        }
        public ActionResult PartialPersonelLogin()
        {
            return View();

        }
        [HttpPost]
        public ActionResult PartialPersonelLogin(Admin admin)
        {
            var Inf=db.Admins.FirstOrDefault(x=>x.AdminName == admin.AdminName && x.Password==admin.Password);
            if (Inf!= null)
            {
                FormsAuthentication.SetAuthCookie(Inf.AdminName, false);
                Session["AdminName"]=Inf.AdminName.ToString();
                return RedirectToAction("Index", "Categories");

            }
            else
            {
                return RedirectToAction("Index", "Login");
            }

        }
    }
}