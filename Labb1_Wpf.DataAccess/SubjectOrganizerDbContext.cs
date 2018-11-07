using Labb1.Model;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Labb1_Wpf.DataAccess
{
    public class SubjectOrganizerDbContext : DbContext
    {
        public SubjectOrganizerDbContext() : base("SubjectOrganizerDb")
        {

        }

        public DbSet<Subject> Subjects { get; set; }
        public DbSet<WeekDay> WeekDays { get; set; }
        public DbSet<WeekNr> WeekNumbers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
