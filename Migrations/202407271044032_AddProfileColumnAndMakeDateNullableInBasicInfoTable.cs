namespace MyPortfolio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProfileColumnAndMakeDateNullableInBasicInfoTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BasicInfo", "Profile", c => c.String());
            AlterColumn("dbo.BasicInfo", "BirthDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BasicInfo", "BirthDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.BasicInfo", "Profile");
        }
    }
}
