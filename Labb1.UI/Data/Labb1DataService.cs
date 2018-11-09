using Labb1.Model;
using Labb1_Wpf.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb1.UI.Data
{
    public class Labb1DataService : ILabb1DataService
    {
        public IEnumerable<WeekNr> GetAll()
        {
            using (var ctx = new SubjectOrganizerDbContext())
            {
                //ctx.Entry<WeekNr>().Reference(w => w.WeekDay.Subject).Load();
                return ctx.WeekNumbers.Include(d => d.WeekDay).Include(d => d.WeekDay.Subject).AsNoTracking().ToList();
            }
        }

        public SubjectOrganizerDbContext GetDbContext()
        {
            return new SubjectOrganizerDbContext();
        }
    }
}
