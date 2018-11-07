using System.Collections.Generic;
using Labb1.Model;

namespace Labb1.UI.Data
{
    public interface ILabb1DataService
    {
        IEnumerable<WeekNr> GetAll();
    }
}