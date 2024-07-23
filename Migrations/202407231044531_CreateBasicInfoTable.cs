namespace MyPortfolio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateBasicInfoTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BasicInfoes",
                c => new
                    {
                        BasicInfoId = c.Guid(nullable: false),
                        PortfolioUserId = c.Guid(nullable: false),
                        Name = c.String(),
                        Address = c.String(),
                        PhoneNumber = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        Designation = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.BasicInfoId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BasicInfoes");
        }
    }
}
