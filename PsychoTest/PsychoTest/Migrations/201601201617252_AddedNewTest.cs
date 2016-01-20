namespace PsychoTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNewTest : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ConfusedLinesTestResults",
                c => new
                    {
                        ResultId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Date = c.DateTime(nullable: false),
                        ErrorsCount = c.Int(nullable: false),
                        Time = c.Double(nullable: false),
                        Result = c.String(),
                    })
                .PrimaryKey(t => t.ResultId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ConfusedLinesTestResults");
        }
    }
}
