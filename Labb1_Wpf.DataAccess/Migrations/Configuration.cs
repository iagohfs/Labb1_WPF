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
            context.WeekNumbers.AddOrUpdate(
                new WeekNr { WeekNumber = 43, WeekDay = new WeekDay { WeekDayInput = "Thursday", Subject = new Subject("Kursstart") } },
                new WeekNr { WeekNumber = 43, WeekDay = new WeekDay { WeekDayInput = "Friday", Subject = new Subject("WPF och labhandledning") } },
                new WeekNr { WeekNumber = 44, WeekDay = new WeekDay { WeekDayInput = "Tuesday", Subject = new Subject("Umbraco-certifiering") } },
                new WeekNr { WeekNumber = 44, WeekDay = new WeekDay { WeekDayInput = "Wednesday", Subject = new Subject("Umbraco-certifiering") } },
                new WeekNr { WeekNumber = 44, WeekDay = new WeekDay { WeekDayInput = "Thursday", Subject = new Subject("Entity Framework återblick och fördjupning") } },
                new WeekNr { WeekNumber = 45, WeekDay = new WeekDay { WeekDayInput = "Tuesday", Subject = new Subject("intro till WCF Labhandledning och redovisninga") } },
                new WeekNr { WeekNumber = 45, WeekDay = new WeekDay { WeekDayInput = "Thursday", Subject = new Subject("WCF endpoints och konfiguration\nSista dagen för redovisningar av lab 1.") } },
                new WeekNr { WeekNumber = 45, WeekDay = new WeekDay { WeekDayInput = "Friday", Subject = new Subject("WCF fördjupning") } }
                );
        }
    }
}
