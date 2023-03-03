namespace OnlineECommerceApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migDetay : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Details",
                c => new
                    {
                        DetailId = c.Int(nullable: false, identity: true),
                        ProductName = c.String(maxLength: 30),
                        ProductDesc = c.String(maxLength: 2000),
                    })
                .PrimaryKey(t => t.DetailId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Details");
        }
    }
}
