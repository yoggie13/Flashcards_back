﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST.Model
{
    public class Subject
    {
        public int SubjectID { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public int Semester { get; set; }
        public Department Department { get; set; }
    }
}
