using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb1.Model
{
    public class WeekDay
    {
        public int Id { get; set; }

        public string WeekDayInput { get; set; }

        public Subject Subject { get; set; }
        
    }
}
