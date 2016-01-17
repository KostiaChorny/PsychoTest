namespace PsychoTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PartResults",
                c => new
                    {
                        PartResultId = c.Int(nullable: false, identity: true),
                        Part = c.Int(nullable: false),
                        Time = c.Double(nullable: false),
                        QuestionsCount = c.Int(nullable: false),
                        ErrorsCount = c.Int(nullable: false),
                        StrupResult_ResultId = c.Int(),
                    })
                .PrimaryKey(t => t.PartResultId)
                .ForeignKey("dbo.StrupResults", t => t.StrupResult_ResultId)
                .Index(t => t.StrupResult_ResultId);
            
            CreateTable(
                "dbo.StrupResults",
                c => new
                    {
                        ResultId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ResultId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PartResults", "StrupResult_ResultId", "dbo.StrupResults");
            DropIndex("dbo.PartResults", new[] { "StrupResult_ResultId" });
            DropTable("dbo.StrupResults");
            DropTable("dbo.PartResults");
        }
    }
}
