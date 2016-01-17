namespace PsychoTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddReverceId : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.PartResults", "StrupResult_ResultId", "dbo.StrupResults");
            //DropIndex("dbo.PartResults", new[] { "StrupResult_ResultId" });
            //AddColumn("dbo.PartResults", "StrupResult_ResultId1", c => c.Int());
            //AlterColumn("dbo.PartResults", "StrupResult_ResultId", c => c.Int(nullable: false));
            //CreateIndex("dbo.PartResults", "StrupResult_ResultId1");
            //AddForeignKey("dbo.PartResults", "StrupResult_ResultId1", "dbo.StrupResults", "ResultId");
        }
        
        public override void Down()
        {
            //DropForeignKey("dbo.PartResults", "StrupResult_ResultId1", "dbo.StrupResults");
            //DropIndex("dbo.PartResults", new[] { "StrupResult_ResultId1" });
            //AlterColumn("dbo.PartResults", "StrupResult_ResultId", c => c.Int());
            //DropColumn("dbo.PartResults", "StrupResult_ResultId1");
            //CreateIndex("dbo.PartResults", "StrupResult_ResultId");
            //AddForeignKey("dbo.PartResults", "StrupResult_ResultId", "dbo.StrupResults", "ResultId");
        }
    }
}
