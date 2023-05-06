using System;

namespace ProgramKadrowy_WPF.Models.Domains
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ContractId { get; set; }
        public Contract Contract { get; set; }
        public string Comments { get; set; }
        public decimal Salary { get; set; }
        public DateTime EmploymentDate { get; set; }
        public DateTime? UnemploymentDate { get; set; }
        public bool IsCurrentlyHired { get; set; }
    }
}
