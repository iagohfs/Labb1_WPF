using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb1.Model
{
    public class WeekNr
    {
        public int Id { get; set; }

        public int WeekNumber { get; set; }
        
        public WeekNr(int UserInput)
        {
            WeekNumber = UserInput;
        }
    }
}
