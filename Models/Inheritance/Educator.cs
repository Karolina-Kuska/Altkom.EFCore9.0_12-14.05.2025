﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Inheritance
{
    public class Educator : Person
    {
        public string Specialization { get; set; }
        public float Salary { get; set; }
    }
}
