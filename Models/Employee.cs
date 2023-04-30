﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramKadrowy_WPF.Models
{
    public class Employee
    {
        public Employee()
        {
            Contract = new Contract();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Contract Contract { get; set; }
        public string Comments { get; set; }
        public decimal Salary { get; set; }
        public DateTime EmploymentDate { get; set; }
        public DateTime? UnemploymentDate { get; set; }
        public bool IsCurrentlyHired { get; set; }
    }
}
