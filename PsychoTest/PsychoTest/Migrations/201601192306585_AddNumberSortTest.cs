namespace PsychoTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNumberSortTest : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NumberSortResults",
                c => new
                    {
                        ResultId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Date = c.DateTime(nullable: false),
                        Time = c.Double(nullable: false),
                        ErrorCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ResultId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.NumberSortResults");
        }
    }
}
