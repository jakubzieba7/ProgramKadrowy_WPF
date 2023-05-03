using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramKadrowy_WPF.Models.Wrappers
{
    public class EmployeeWrapper
    {
        public EmployeeWrapper()
        {
            Contract = new ContractWrapper();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ContractWrapper Contract { get; set; }
        public string Comments { get; set; }
        public decimal Salary { get; set; }
        public DateTime EmploymentDate { get; set; }
        public DateTime? UnemploymentDate { get; set; }
        public bool IsCurrentlyHired { get; set; }
    }
}
