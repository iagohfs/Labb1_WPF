using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb1.Model
{
    public class Subject
    {
        public int Id { get; set; }

        public string SubjectName { get; set; }

        public int Week { get; set; }

        public int WeekDayNr { get; set; }

        //public string GetWeekDay { get => CovertWeekDay();}

        public string CovertWeekDay()
        {
            switch (this.WeekDayNr)
            {
                case 1:
                    return "Monday";
                case 2:
                    return "Tuesday";
                case 3:
                    return "Wednesday";
                case 4:
                    return "Thursday";
                case 5:
                    return "Friday";

                default:
                    return "Empty";
            }
        }
    }
}
