namespace MyPortfolio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateHobbyTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Hobby",
                c => new
                    {
                        HobbyId = c.Guid(nullable: false),
                        PortfolioUserId = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 60),
                    })
                .PrimaryKey(t => t.HobbyId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Hobby");
        }
    }
}
