namespace OnlineECommerceApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig11 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BillPencils", "Bill_BillID", "dbo.Bills");
            DropIndex("dbo.BillPencils", new[] { "Bill_BillID" });
            RenameColumn(table: "dbo.BillPencils", name: "Bill_BillID", newName: "BillId");
            AlterColumn("dbo.BillPencils", "BillId", c => c.Int(nullable: false));
            CreateIndex("dbo.BillPencils", "BillId");
            AddForeignKey("dbo.BillPencils", "BillId", "dbo.Bills", "BillID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BillPencils", "BillId", "dbo.Bills");
            DropIndex("dbo.BillPencils", new[] { "BillId" });
            AlterColumn("dbo.BillPencils", "BillId", c => c.Int());
            RenameColumn(table: "dbo.BillPencils", name: "BillId", newName: "Bill_BillID");
            CreateIndex("dbo.BillPencils", "Bill_BillID");
            AddForeignKey("dbo.BillPencils", "Bill_BillID", "dbo.Bills", "BillID");
        }
    }
}
