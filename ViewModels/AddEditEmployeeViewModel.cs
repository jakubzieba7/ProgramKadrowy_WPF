using ProgramKadrowy_WPF.Commands;
using ProgramKadrowy_WPF.Models.Domains;
using ProgramKadrowy_WPF.Models.Wrappers;
using System.Collections.ObjectModel;
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
                Employee = new EmployeeWrapper() { IsCurrentlyHired=true};
            }
            else
            {
                Employee = employee;
                IsUpdate = true;
            }

            _isTerminated = !Employee.IsCurrentlyHired;
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

        private bool _isTerminated;

        public bool IsTerminated
        {
            get
            {
                return _isTerminated;
            }
            set
            {
                _isTerminated = value;
                OnPropertyChanged();
            }
        }

        private void Confirm(object obj)
        {
            if (!Employee.IsValid)
                return;

            if (!IsUpdate)
                AddEmployee();
            else
                UpdateEmployee();

            CloseWindow(obj as Window);
        }

        private void AddEmployee()
        {
            _repository.AddEmployee(Employee);
        }

        private void UpdateEmployee()
        {
            _repository.UpdateEmployee(Employee);
        }

        private void Close(object obj)
        {
            CloseWindow(obj as Window);
        }

        private void CloseWindow(Window window)
        {
            window.Close();
        }
        private int _selectedContractId;

        public int SelectedContractId
        {
            get
            {
                return _selectedContractId;
            }
            set
            {
                _selectedContractId = value;
                OnPropertyChanged();
            }
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

            SelectedContractId = Employee.Contract.Id;
        }

    }
}
