using Labb1.Model;
using Labb1_Wpf.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb1.UI.Data
{
    public class Labb1DataService : ILabb1DataService
    {
        public IEnumerable<Subject> GetAll()
        {
            using (var ctx = new SubjectOrganizerDbContext())
            {
                return ctx.Subjects.AsNoTracking().ToList();
            }
        }        
    }
}
