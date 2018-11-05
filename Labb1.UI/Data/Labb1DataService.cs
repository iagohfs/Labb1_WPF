using Labb1.Model;
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
            //lägg till databas
            yield return new Subject { Id = 43, SubjectName = "Kursstart" };
            yield return new Subject { Id = 43, SubjectName = "WPF och labhandledning" };
            yield return new Subject { Id = 44, SubjectName = "Umbraco-certifiering" };
            yield return new Subject { Id = 44, SubjectName = "Umbraco-certifiering" };
            yield return new Subject { Id = 44, SubjectName = "Entity Framework återblick och fördjupning" };
        }
    }
}
