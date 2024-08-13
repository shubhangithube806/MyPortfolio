namespace MyPortfolio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakePercentageOrCGPAColumnNullableInEducationTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Education", "PercentageOrCGPA", c => c.Double());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Education", "PercentageOrCGPA", c => c.Double(nullable: false));
        }
    }
}
