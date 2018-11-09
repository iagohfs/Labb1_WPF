namespace Labb1_Wpf.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hello : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Subject",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubjectInfo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WeekDay",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WeekDayInput = c.String(),
                        Subject_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Subject", t => t.Subject_Id)
                .Index(t => t.Subject_Id);
            
            CreateTable(
                "dbo.WeekNr",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WeekNumber = c.Int(nullable: false),
                        WeekDay_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.WeekDay", t => t.WeekDay_Id)
                .Index(t => t.WeekDay_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WeekNr", "WeekDay_Id", "dbo.WeekDay");
            DropForeignKey("dbo.WeekDay", "Subject_Id", "dbo.Subject");
            DropIndex("dbo.WeekNr", new[] { "WeekDay_Id" });
            DropIndex("dbo.WeekDay", new[] { "Subject_Id" });
            DropTable("dbo.WeekNr");
            DropTable("dbo.WeekDay");
            DropTable("dbo.Subject");
        }
    }
}
