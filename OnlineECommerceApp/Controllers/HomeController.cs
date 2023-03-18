using OnlineECommerceApp.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace OnlineECommerceApp.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
       

        private Context db = new Context(); 
        public ActionResult Index(string p)
        {
            var products = from x in db.Products select x;
            var basket = GetCart().Lines.Count();
            ViewBag.basket = basket;
            if (!string.IsNullOrEmpty(p))
            {
                products = products.Where(y => y.ProductName.Contains(p));
            }
            return View(products.ToList().Take(3));

        }

        public ActionResult Store(string p, int page=1)
        {
            var products = from x in db.Products select x;
            if (!string.IsNullOrEmpty(p))
            {
                products = products.Where(y => y.ProductName.Contains(p));
            }

            var productCount = db.Products.Count().ToString();
            ViewBag.ProductCount = productCount;
            return View(products.ToList().ToPagedList(page,6));

        }
        public PartialViewResult Basket()
        {
            return PartialView(GetCart());
        }

        public ActionResult Cart()
        {
          
            return View(GetCart());
        }
        [HttpPost]

        public ActionResult AddToCart(int ProductId)
        {
            var product = db.Products.FirstOrDefault(i => i.ProductID == ProductId);

            if (product != null)
            {
                GetCart().AddItem(product, 1);

            }
            return RedirectToAction("Cart","Home");
        }

        [HttpPost]

        public ActionResult RemoveToItem(int ProductId)
        {
            var product = db.Products.FirstOrDefault(i => i.ProductID == ProductId);

            if (product != null)
            {
                GetCart().RemoveItem(product, 1);

            }
           
            return RedirectToAction("Cart", "Home");
        }

        [HttpPost]

        public ActionResult RemoveFromCart(int ProductId)
        {
            var product = db.Products.FirstOrDefault(i => i.ProductID == ProductId);

            if (product != null)
            {
                GetCart().RemoveLine(product);

            }
            return RedirectToAction("Cart","Home");
        }

        public Cart GetCart()
        {
            var cart = (Cart)Session["Cart"];
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }

            return cart;
        }

        public PartialViewResult Summary()
        {
            return PartialView(GetCart());
        }
        public ActionResult CheckOut()
        {
            var total = GetCart().ComputeTotalValue();
            var totalSum = Convert.ToInt32(total) + 10;
            ViewBag.Total = total;  
            ViewBag.TotalSum = totalSum;
        
            return View(new ShippingDetail());
        }
      

        [HttpPost]
        public ActionResult RemoveOrder(int? id)
        {
      
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Order order = db.Orders.Where(x=>x.CariId==id).FirstOrDefault();
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
            
        }

        [HttpGet]
        public ActionResult GetByProduct(int? id)
        {
           var product=db.Products.Where(x => x.CategoryId == id);   
            return View(product);
        }
     

        [HttpPost]
        public ActionResult CheckOut(ShippingDetail entity)
        {
            var cart = GetCart();
            if (cart.Lines.Count == 0)
            {
                ModelState.AddModelError("UrunYokError", "Sepetinizde ürün bulunmamaktadır.");
            }

            if (ModelState.IsValid)
            {
                SaveOrder(cart, entity);
                cart.Clear();
                return RedirectToAction("Complated","Home");
            }
            else
            {
                return View(entity);
            }

        }
        public ActionResult Complated()
        {
            return View(new OrderDetailsModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Order(SalesAction salesAction, ShippingDetail entity)
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

        public ActionResult CargoDetails()
        {
            var mail = (string)Session["CMail"];
            var id = db.Caris.Where(x => x.CMail == mail.ToString()).Select(y => y.CariID).FirstOrDefault();
            return View(db.CargoDetails.Where(x=>x.CariId==id).ToList());
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
        private void SaveOrder(Cart cart, ShippingDetail entity)
        {
            var mail = (string)Session["CMail"];
            var id = db.Caris.Where(x => x.CMail == mail.ToString()).Select(y => y.CariID).FirstOrDefault();
            

            var order = new Order
            {
                OrderNumber = "A" + (new Random()).Next(111111, 999999).ToString(),
                Total = Convert.ToDouble(cart.ComputeTotalValue()),
                OrderDate = DateTime.Now,
                OrderState = EnumOrderState.Created,
                FirstName = entity.FirstName,
                AddressTitle = entity.AddressTitle,
                Street = entity.Street,
                Neighborhood = entity.Neighborhood,
                City = entity.City,
                PostalCode = entity.PostalCode,
                ZipCode = entity.ZipCode,
                CariId = id,/*(id==null ? (new Random()).Next(111111, 999999) : id),*/
                Orderlines = new List<OrderLine>()
            };


            foreach (var pr in cart.Lines)
            {
                var orderline = new OrderLine
                {
                    Quantity = pr.Quantity,
                    Price = Convert.ToDouble(pr.Quantity * pr.Product.SalesPrice),
                    ProductId = pr.Product.ProductID
                };

                order.Orderlines.Add(orderline);
            }

            db.Orders.Add(order);
            db.SaveChanges();
        }
        public ActionResult MyOrders()

        {
            var total = GetCart().ComputeTotalValue();    
            ViewBag.Total = total;  
            var mail = (string)Session["CMail"];
            var id = db.Caris.Where(x => x.CMail == mail.ToString()).Select(y => y.CariID).FirstOrDefault();
            var orders = db.Orders.Where(x => x.CariId == id)
             .Select(x => new UserOrderModel()
             {
                 Id = x.Id,
                 Total = x.Total,
                 OrderNumber = x.OrderNumber,
                 OrderState = x.OrderState,
                 OrderDate = x.OrderDate
             }).OrderByDescending(x => x.OrderDate)
             .ToList();
            return View(orders);
         
        }

        public ActionResult OrderDetails(int? id)
        {

            var entity = db.Orders.Where(x => x.Id == id)
                .Select(x => new OrderDetailsModel()
                {
                    OrderId = x.Id,
                    OrderNumber = x.OrderNumber,
                    Total = x.Total,
                    OrderDate = x.OrderDate,
                    OrderState = x.OrderState,
                    AddressTitle = x.AddressTitle,
                    Street = x.Street,
                    City = x.City,
                    Neighborhood = x.Neighborhood,
                    Building= x.Building,
                    PostalCode = x.PostalCode,
                    ZipCode = x.ZipCode,    
                    Orderlines = x.Orderlines.Select(a => new OrderLineModel()
                    {
                        Quantity = a.Quantity,
                        Price = a.Price,
                        ProductId = a.ProductId,
                        ProductName = a.Product.ProductName.Length > 50 ? a.Product.ProductName.Substring(0, 40) + ".." : a.Product.ProductName,
                        Image = a.Product.ProductImage
                    }).ToList()
                }).FirstOrDefault();

            return View();
        }


        public ActionResult ProductDetail(int? id)
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
        public PartialViewResult PartialCategory()
        {
            var query = db.Categories.ToList(); 
            return PartialView(query);
        }
        public PartialViewResult PartialCategory2()
        {
            var query = db.Categories.ToList();
            return PartialView(query);
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}