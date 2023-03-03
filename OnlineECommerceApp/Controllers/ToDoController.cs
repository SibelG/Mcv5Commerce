using OnlineECommerceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineECommerceApp.Controllers
{
    public class ToDoController : Controller
    {
        private Context db = new Context();
        // GET: ToDo
        public ActionResult Index()
        {
            var d1=db.Caris.Count().ToString();
            ViewBag.dgr1 = d1;
            var d2 = db.Products.Count().ToString();
            ViewBag.dgr2 = d2;
            var d3 = db.Categories.Count().ToString();
            ViewBag.dgr3 = d3;
            var d4=(from x in db.Caris select x.CCity).Distinct().Count().ToString();
            ViewBag.dgr4 = d4;

            var TodoList = db.ToDoes.ToList();
            return View(TodoList);
        }
    }
}