namespace OnlineECommerceApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig6 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Products", name: "Category_CategoryID", newName: "CategoryId");
            RenameIndex(table: "dbo.Products", name: "IX_Category_CategoryID", newName: "IX_CategoryId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Products", name: "IX_CategoryId", newName: "IX_Category_CategoryID");
            RenameColumn(table: "dbo.Products", name: "CategoryId", newName: "Category_CategoryID");
        }
    }
}
