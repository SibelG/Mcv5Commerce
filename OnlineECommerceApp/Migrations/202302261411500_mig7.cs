namespace OnlineECommerceApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig7 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Personels", name: "Department_DepartmentID", newName: "DepartmentId");
            RenameIndex(table: "dbo.Personels", name: "IX_Department_DepartmentID", newName: "IX_DepartmentId");
            AddColumn("dbo.Departments", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Departments", "Status");
            RenameIndex(table: "dbo.Personels", name: "IX_DepartmentId", newName: "IX_Department_DepartmentID");
            RenameColumn(table: "dbo.Personels", name: "DepartmentId", newName: "Department_DepartmentID");
        }
    }
}
