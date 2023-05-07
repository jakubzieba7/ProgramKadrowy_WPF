using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProgramKadrowy_WPF.Models.Wrappers
{
    public class EmployeeWrapper : IDataErrorInfo
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
        public bool IsCurrentlyHired { get; set; }

       

        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case nameof(FirstName):
                        if (string.IsNullOrWhiteSpace(FirstName))
                        {
                            Error = "Pole Imię jest wymagane.";
                            _isFirstNameValid = false;
                        }
                        else
                        {
                            Error = string.Empty;
                            _isFirstNameValid = true;
                        }
                        break;
                    case nameof(LastName):
                        if (string.IsNullOrWhiteSpace(LastName))
                        {
                            Error = "Pole Nazwisko jest wymagane.";
                            _isLastNameValid = false;
                        }
                        else
                        {
                            Error = string.Empty;
                            _isLastNameValid = true;
                        }
                        break;
                    case nameof(EmploymentDate):
                        if (string.IsNullOrWhiteSpace(EmploymentDate.ToString()))
                        {
                            Error = "Pole Data zatrudnienia jest wymagane.";
                            _isEmploymentDateValid = false;
                        }
                        else
                        {
                            Error = string.Empty;
                            _isEmploymentDateValid = true;
                        }
                        break;
                    default:
                        break;
                }
                return Error;
            }
        }

        public string Error { get; set; }

        private bool _isEmploymentDateValid;
        private bool _isLastNameValid;
        private bool _isFirstNameValid;

        public bool IsValid
        {
            get
            {
                return _isFirstNameValid && _isLastNameValid && _isEmploymentDateValid && Contract.IsValid;
            }
        }
    }
}
