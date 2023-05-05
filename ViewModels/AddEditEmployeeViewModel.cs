using ProgramKadrowy_WPF.Commands;
using ProgramKadrowy_WPF.Models;
using ProgramKadrowy_WPF.Models.Domains;
using ProgramKadrowy_WPF.Models.Wrappers;
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
        private Repository _repository = new Repository();
        public AddEditEmployeeViewModel(EmployeeWrapper employee = null)
        {

            CloseCommand = new RelayCommand(Close);
            ConfirmCommand = new RelayCommand(Confirm);

            if (employee == null)
            {
                Employee = new EmployeeWrapper();
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

        private EmployeeWrapper _employee;

        public EmployeeWrapper Employee
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
            var contracts = _repository.GetContract();
            contracts.Insert(0, new Contract { Id = 0, Name = "-- brak --" });

            Contracts = new ObservableCollection<Contract>(contracts);

            Employee.Contract.Id = 0;
        }

    }
}
