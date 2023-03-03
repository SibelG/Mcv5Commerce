namespace OnlineECommerceApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig101 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bills", "Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.Bills", "SubTotal", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Bills", "Time", c => c.String(maxLength: 5));
            DropColumn("dbo.Bills", "Tarih");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Bills", "Tarih", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Bills", "Time", c => c.DateTime(nullable: false));
            DropColumn("dbo.Bills", "SubTotal");
            DropColumn("dbo.Bills", "Date");
        }
    }
}
