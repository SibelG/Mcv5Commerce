namespace OnlineECommerceApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig9 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SalesActions", "Date", c => c.DateTime(nullable: false));
            DropColumn("dbo.SalesActions", "Tarih");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SalesActions", "Tarih", c => c.DateTime(nullable: false));
            DropColumn("dbo.SalesActions", "Date");
        }
    }
}
