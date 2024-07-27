namespace MyPortfolio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDataAnnotationsToBasicInfo : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BasicInfo", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.BasicInfo", "Address", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.BasicInfo", "PhoneNumber", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.BasicInfo", "BirthDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.BasicInfo", "Designation", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.BasicInfo", "Email", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.BasicInfo", "Profile", c => c.String(nullable: false, maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BasicInfo", "Profile", c => c.String());
            AlterColumn("dbo.BasicInfo", "Email", c => c.String());
            AlterColumn("dbo.BasicInfo", "Designation", c => c.String());
            AlterColumn("dbo.BasicInfo", "BirthDate", c => c.DateTime());
            AlterColumn("dbo.BasicInfo", "PhoneNumber", c => c.String());
            AlterColumn("dbo.BasicInfo", "Address", c => c.String());
            AlterColumn("dbo.BasicInfo", "Name", c => c.String());
        }
    }
}
