namespace OnlineECommerceApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig8 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.SalesActions", name: "Cari_CariID", newName: "CariId");
            RenameColumn(table: "dbo.SalesActions", name: "Personel_PersonelID", newName: "PersonelId");
            RenameColumn(table: "dbo.SalesActions", name: "Product_ProductID", newName: "ProductId");
            RenameIndex(table: "dbo.SalesActions", name: "IX_Product_ProductID", newName: "IX_ProductId");
            RenameIndex(table: "dbo.SalesActions", name: "IX_Cari_CariID", newName: "IX_CariId");
            RenameIndex(table: "dbo.SalesActions", name: "IX_Personel_PersonelID", newName: "IX_PersonelId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.SalesActions", name: "IX_PersonelId", newName: "IX_Personel_PersonelID");
            RenameIndex(table: "dbo.SalesActions", name: "IX_CariId", newName: "IX_Cari_CariID");
            RenameIndex(table: "dbo.SalesActions", name: "IX_ProductId", newName: "IX_Product_ProductID");
            RenameColumn(table: "dbo.SalesActions", name: "ProductId", newName: "Product_ProductID");
            RenameColumn(table: "dbo.SalesActions", name: "PersonelId", newName: "Personel_PersonelID");
            RenameColumn(table: "dbo.SalesActions", name: "CariId", newName: "Cari_CariID");
        }
    }
}
