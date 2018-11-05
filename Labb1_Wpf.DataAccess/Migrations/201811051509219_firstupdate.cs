namespace Labb1_Wpf.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstupdate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Subject",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubjectName = c.String(),
                        Week = c.Int(nullable: false),
                        WeekDayNr = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Subject");
        }
    }
}
