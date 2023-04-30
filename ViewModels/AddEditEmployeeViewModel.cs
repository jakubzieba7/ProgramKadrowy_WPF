using ProgramKadrowy_WPF.Commands;
using ProgramKadrowy_WPF.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ProgramKadrowy_WPF.ViewModels
{
    public class AddEditEmployeeViewModel : ViewModelBase
    {
        public AddEditEmployeeViewModel(Employee employee = null)
        {

            CloseCommand = new RelayCommand(Close);
            ConfirmCommand = new RelayCommand(Confirm);

            if (employee == null)
            {
                Employee = new Employee();
            }
            else
            {
                Employee = employee;
                IsUpdate = true;
            }

            InitContracts();
        }



        public ICommand CloseCommand { get; set; }
        public ICommand ConfirmCommand { get; set; }

        private Employee _employee;

        public Employee Employee
        {
            get
            {
                return _employee;
            }
            set
            {
                _employee = value;
                OnPropertyChanged();
            }
        }

        private bool _isUpdate;

        public bool IsUpdate
        {
            get
            {
                return _isUpdate;
            }
            set
            {
                _isUpdate = value;
                OnPropertyChanged();
            }
        }


        private void Confirm(object obj)
        {
            if (!IsUpdate)
                AddEmployee();
            else
                UpdateEmployee();

            CloseWindow(obj as Window);
        }

        private void AddEmployee()
        {
            throw new NotImplementedException();
        }

        private void UpdateEmployee()
        {
            throw new NotImplementedException();
        }

        private void Close(object obj)
        {
            CloseWindow(obj as Window);
        }

        private void CloseWindow(Window window)
        {
            window.Close();
        }

        private ObservableCollection<Contract> _contracts;

        public ObservableCollection<Contract> Contracts
        {
            get
            {
                return _contracts;
            }
            set
            {
                _contracts = value;
                OnPropertyChanged();
            }
        }

        private void InitContracts()
        {
            Contracts = new ObservableCollection<Contract>
            {
            new Contract {Id=0,Name="-- brak --"},
            new Contract {Id=1,Name="UOP_okres_próbny"},
            new Contract {Id=2,Name="UOP_czas_określony"},
            new Contract {Id=3,Name="UOP_czas_nieokreślony"},
            new Contract {Id=4,Name="B2B"}
            };

            Employee.Contract.Id = 0;
        }

    }
}
