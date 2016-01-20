namespace PsychoTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeignKey : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.PartResults", name: "StrupResult_ResultId1", newName: "TestResult_ResultId");
            RenameIndex(table: "dbo.PartResults", name: "IX_StrupResult_ResultId1", newName: "IX_TestResult_ResultId");
            DropColumn("dbo.PartResults", "StrupResult_ResultId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PartResults", "StrupResult_ResultId", c => c.Int(nullable: false));
            RenameIndex(table: "dbo.PartResults", name: "IX_TestResult_ResultId", newName: "IX_StrupResult_ResultId1");
            RenameColumn(table: "dbo.PartResults", name: "TestResult_ResultId", newName: "StrupResult_ResultId1");
        }
    }
}
