namespace MyPortfolio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LinkTableAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Link",
                c => new
                    {
                        LinkId = c.Guid(nullable: false),
                        PortfolioUserId = c.Guid(nullable: false),
                        LinkText = c.String(nullable: false, maxLength: 1000),
                        LinkType = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.LinkId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Link");
        }
    }
}
