namespace OnlineECommerceApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migImage : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Personels", "PImage", c => c.String(maxLength: 2000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Personels", "PImage", c => c.String(maxLength: 30));
        }
    }
}
