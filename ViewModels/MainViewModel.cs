using ProgramKadrowy_WPF.Commands;
using ProgramKadrowy_WPF.Models.Domains;
using ProgramKadrowy_WPF.Models.Wrappers;
using ProgramKadrowy_WPF.Properties;
using ProgramKadrowy_WPF.Views;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ProgramKadrowy_WPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private Repository _repository = new Repository();
        public MainViewModel()
        {
            //First query in order to create Database if not exists
            //using (var context = new ApplicationDBContext())
            //{
            //    var employyes = context.Employees.ToList();
            //}

            AddEmployeeCommand = new RelayCommand(AddEditEmployeeData);
            EditEmployeeCommand = new RelayCommand(AddEditEmployeeData, CanEditEmployeeData);
            RefreshEmployeeCommand = new RelayCommand(RefreshEmployeeData);
            SQLSettingsCommand = new RelayCommand(AddEditSQLSettings);


            RefreshEmployeeList();
            InitContracts();
        }


        public ICommand SQLSettingsCommand { get; set; }
        public ICommand RefreshEmployeeCommand { get; set; }
        public ICommand EditEmployeeCommand { get; set; }
        public ICommand AddEmployeeCommand { get; set; }

        private EmployeeWrapper _selectedEmployee;

        public EmployeeWrapper SelectedEmployee
        {
            get
            {
                return _selectedEmployee;
            }
            set
            {
                _selectedEmployee = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<EmployeeWrapper> _employees;

        public ObservableCollection<EmployeeWrapper> Employees
        {
            get
            {
                return _employees;
            }
            set
            {
                _employees = value;
                OnPropertyChanged();
            }
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

        private void AddEditEmployeeData(object obj)
        {
            var addEditEmployeeWindow = new AddEditEmployeeView(obj as EmployeeWrapper);
            addEditEmployeeWindow.Closed += AddEditEmployeeWindow_Closed;
            addEditEmployeeWindow.ShowDialog();
        }

        private void AddEditEmployeeWindow_Closed(object sender, EventArgs e)
        {
            RefreshEmployeeList();
        }

        private bool CanEditEmployeeData(object obj)
        {
            return SelectedEmployee != null;

        }
        private void RefreshEmployeeData(object obj)
        {
            throw new NotImplementedException();
        }
        private void AddEditSQLSettings(object obj)
        {
            var addEditSQLSettingsWindow = new SQLSettingsView(true);
            addEditSQLSettingsWindow.Closed += AddEditSQLSettingsWindow_Closed;
            addEditSQLSettingsWindow.ShowDialog();
        }

        private void AddEditSQLSettingsWindow_Closed(object sender, EventArgs e)
        {
            Settings.Default.Save();
        }

        private void InitContracts()
        {
            var contracts = _repository.GetContract();
            contracts.Insert(0, new Contract { Id = 0, Name = "Wszystkie" });

            Contracts = new ObservableCollection<Contract>(contracts);

            SelectedContractId = 0;
        }

        private void RefreshEmployeeList()
        {
            Employees = new ObservableCollection<EmployeeWrapper>(_repository.GetEmployees(SelectedContractId));
        }
    }
}
