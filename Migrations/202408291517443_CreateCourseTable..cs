namespace MyPortfolio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateCourseTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Course",
                c => new
                    {
                        CourseId = c.Guid(nullable: false),
                        PortfolioUserId = c.Guid(nullable: false),
                        CourseName = c.String(nullable: false, maxLength: 100),
                        CoursePlatform = c.String(nullable: false, maxLength: 100),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(),
                        Description = c.String(nullable: false, maxLength: 1000),
                        Skills = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.CourseId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Course");
        }
    }
}
