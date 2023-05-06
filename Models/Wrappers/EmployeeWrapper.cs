using System;
using System.Collections.Generic;
using System.Globalization;
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
        public DateTime? EmploymentDate { get; set; }
        

        private DateTime? _unemploymentDate = DateTime.Now;
        public DateTime? UnemploymentDate 
        {
            get 
            {
                return _unemploymentDate;
            }
            set 
            { 
                _unemploymentDate = value; 
            } 
        }
        //public string FormattedUnemploymentDate
        //{
        //    get {
        //        if (!string.IsNullOrEmpty(_unemploymentDate.ToString()))
        //            return _unemploymentDate.ToString("D");
        //        else
        //            return null; }
        //}
        public bool IsCurrentlyHired { get; set; }
    }
}
