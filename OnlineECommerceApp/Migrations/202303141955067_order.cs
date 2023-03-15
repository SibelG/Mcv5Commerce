namespace OnlineECommerceApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class order : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.ShippingDetails", name: "cariId", newName: "Cari_CariID");
            RenameIndex(table: "dbo.ShippingDetails", name: "IX_cariId", newName: "IX_Cari_CariID");
            CreateTable(
                "dbo.OrderLines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(),
                        Quantity = c.Int(),
                        Price = c.Double(nullable: false),
                        ProductId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.OrderId)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .Index(t => t.OrderId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderNumber = c.String(),
                        Total = c.Double(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                        OrderState = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        AddressTitle = c.String(),
                        City = c.String(),
                        Neighborhood = c.String(),
                        Street = c.String(),
                        Building = c.String(),
                        PostalCode = c.String(),
                        ZipCode = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.ShippingDetails", "City", c => c.String(nullable: false));
            DropColumn("dbo.ShippingDetails", "Country");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ShippingDetails", "Country", c => c.String(nullable: false));
            DropForeignKey("dbo.OrderLines", "ProductId", "dbo.Products");
            DropForeignKey("dbo.OrderLines", "OrderId", "dbo.Orders");
            DropIndex("dbo.OrderLines", new[] { "ProductId" });
            DropIndex("dbo.OrderLines", new[] { "OrderId" });
            DropColumn("dbo.ShippingDetails", "City");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderLines");
            RenameIndex(table: "dbo.ShippingDetails", name: "IX_Cari_CariID", newName: "IX_cariId");
            RenameColumn(table: "dbo.ShippingDetails", name: "Cari_CariID", newName: "cariId");
        }
    }
}
