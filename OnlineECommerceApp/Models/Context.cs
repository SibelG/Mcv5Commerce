using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OnlineECommerceApp.Models
{
    public class Context: DbContext
    {
       
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Cari> Caris { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<BillPencil> BillPencils { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Personel> Personels { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SalesAction> SalesActions { get; set; }
        public DbSet<Detail> Details { get; set; }
        public DbSet<ToDo> ToDoes { get; set; }
        public DbSet<CargoDetail> CargoDetails { get; set; }
        public DbSet<CargoTracking> CargoTrackings { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }    






    }
}