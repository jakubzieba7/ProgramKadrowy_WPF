﻿using System.ComponentModel;

namespace ProgramKadrowy_WPF.Models.Wrappers
{
    public class ContractWrapper : IDataErrorInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case nameof(Id):
                        if (Id == 0)
                            Error = "Pole Umowa jest wymagane";
                        else
                            Error = string.Empty;
                        break;
                    default:
                        break;
                }

                return Error;
            }
        }
        public string Error { get; set; }

        public bool IsValid
        {
            get
            {
                return string.IsNullOrWhiteSpace(Error);
            }
        }
    }
}