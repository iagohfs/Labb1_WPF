namespace Labb1_Wpf.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstupdate1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WeekDay",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WeekDayInput = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WeekNr",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WeekNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Subject", "WeekDay_Id", c => c.Int());
            AddColumn("dbo.Subject", "WeekNumber_Id", c => c.Int());
            CreateIndex("dbo.Subject", "WeekDay_Id");
            CreateIndex("dbo.Subject", "WeekNumber_Id");
            AddForeignKey("dbo.Subject", "WeekDay_Id", "dbo.WeekDay", "Id");
            AddForeignKey("dbo.Subject", "WeekNumber_Id", "dbo.WeekNr", "Id");
            DropColumn("dbo.Subject", "Week");
            DropColumn("dbo.Subject", "WeekDay");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Subject", "WeekDay", c => c.String());
            AddColumn("dbo.Subject", "Week", c => c.Int(nullable: false));
            DropForeignKey("dbo.Subject", "WeekNumber_Id", "dbo.WeekNr");
            DropForeignKey("dbo.Subject", "WeekDay_Id", "dbo.WeekDay");
            DropIndex("dbo.Subject", new[] { "WeekNumber_Id" });
            DropIndex("dbo.Subject", new[] { "WeekDay_Id" });
            DropColumn("dbo.Subject", "WeekNumber_Id");
            DropColumn("dbo.Subject", "WeekDay_Id");
            DropTable("dbo.WeekNr");
            DropTable("dbo.WeekDay");
        }
    }
}
