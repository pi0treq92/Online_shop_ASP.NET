namespace twoja_manufaktura.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Checkout : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "UserData_Code", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "UserData_City", c => c.String());
            DropColumn("dbo.AspNetUsers", "UserData_CodeAndCity");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "UserData_CodeAndCity", c => c.String());
            DropColumn("dbo.AspNetUsers", "UserData_City");
            DropColumn("dbo.AspNetUsers", "UserData_Code");
        }
    }
}
