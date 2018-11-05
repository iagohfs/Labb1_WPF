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
                s => s.SubjectName,
                new Subject { SubjectName = "Kursstart", Week = 43, WeekDayNr = 4 },
                new Subject { SubjectName = "WPF och labhandledning", Week = 43, WeekDayNr = 5 },
                new Subject { SubjectName = "Umbraco-certifiering", Week = 44, WeekDayNr = 2 },
                new Subject { SubjectName = "Umbraco-certifiering", Week = 44, WeekDayNr = 3 },
                new Subject { SubjectName = "Entity Framework återblick och fördjupning", Week = 44, WeekDayNr = 4 },
                new Subject { SubjectName = "intro till WCF Labhandledning och redovisningar", Week = 45, WeekDayNr = 2 },
                new Subject { SubjectName = "WCF endpoints och konfiguration\nSista dagen för redovisningar av lab 1.", Week = 45, WeekDayNr = 4 },
                new Subject { SubjectName = "WCF fördjupning", Week = 45, WeekDayNr = 5 }
                );
        }
    }
}
