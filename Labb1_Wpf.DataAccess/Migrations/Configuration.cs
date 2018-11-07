namespace Labb1_Wpf.DataAccess.Migrations
{
    using Labb1.Model;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Labb1_Wpf.DataAccess.SubjectOrganizerDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Labb1_Wpf.DataAccess.SubjectOrganizerDbContext context)
        {
            context.Subjects.AddOrUpdate(
                new Subject { SubjectInfo = "Kursstart", WeekNumber = new WeekNr(43), WeekDay = new WeekDay("Thursday") },
                new Subject { SubjectInfo = "WPF och labhandledning", WeekNumber = new WeekNr(43), WeekDay = new WeekDay("Friday") },
                new Subject { SubjectInfo = "Umbraco-certifiering", WeekNumber = new WeekNr(44), WeekDay = new WeekDay("Tuesday") },
                new Subject { SubjectInfo = "Umbraco-certifiering", WeekNumber = new WeekNr(44), WeekDay = new WeekDay("Wednesday") },
                new Subject { SubjectInfo = "Entity Framework återblick och fördjupning", WeekNumber = new WeekNr(44), WeekDay = new WeekDay("Thursday") },
                new Subject { SubjectInfo = "intro till WCF Labhandledning och redovisningar", WeekNumber = new WeekNr(45), WeekDay = new WeekDay("Tuesday") },
                new Subject { SubjectInfo = "WCF endpoints och konfiguration\nSista dagen för redovisningar av lab 1.", WeekNumber = new WeekNr(45), WeekDay = new WeekDay("Thursday") },
                new Subject { SubjectInfo = "WCF fördjupning", WeekNumber = new WeekNr(45), WeekDay = new WeekDay("Friday") }
                );
        }
    }
}
