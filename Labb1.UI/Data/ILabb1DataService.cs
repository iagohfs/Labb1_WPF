using System.Collections.Generic;
using Labb1.Model;
using Labb1_Wpf.DataAccess;

namespace Labb1.UI.Data
{
    public interface ILabb1DataService
    {
        IEnumerable<WeekNr> GetAll();

        SubjectOrganizerDbContext GetDbContext();
    }
}