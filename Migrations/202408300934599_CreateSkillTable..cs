namespace MyPortfolio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateSkillTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Skill",
                c => new
                    {
                        SkillId = c.Guid(nullable: false),
                        PortfolioUserId = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 500),
                    })
                .PrimaryKey(t => t.SkillId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Skill");
        }
    }
}
