﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb1.Model
{
    public class Subject
    {
        public int Id { get; set; }

        public string SubjectInfo { get; set; }

        public WeekNr WeekNumber { get; set; }

        public WeekDay WeekDay { get; set; }

    }
}
