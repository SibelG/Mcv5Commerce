namespace OnlineECommerceApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cargo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CargoDetails",
                c => new
                    {
                        CargoId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        TrackCode = c.String(maxLength: 10),
                        Personel = c.String(),
                        Receiver = c.String(),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CargoId);
            
            CreateTable(
                "dbo.CargoTrackings",
                c => new
                    {
                        CargoTrackId = c.Int(nullable: false, identity: true),
                        CargoCode = c.String(maxLength: 10),
                        Descriptions = c.String(),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CargoTrackId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CargoTrackings");
            DropTable("dbo.CargoDetails");
        }
    }
}
