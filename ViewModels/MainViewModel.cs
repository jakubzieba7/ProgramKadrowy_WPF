using ProgramKadrowy_WPF.Commands;
using ProgramKadrowy_WPF.Models;
using ProgramKadrowy_WPF.Models.Wrappers;
using ProgramKadrowy_WPF.Properties;
using ProgramKadrowy_WPF.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProgramKadrowy_WPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
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

        private ObservableCollection<ContractWrapper> _contracts;

        public ObservableCollection<ContractWrapper> Contracts
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
            Contracts = new ObservableCollection<ContractWrapper>
            {
            new ContractWrapper {Id=0,Name="Wszystkie"},
            new ContractWrapper {Id=1,Name="UOP_okres_próbny"},
            new ContractWrapper {Id=2,Name="UOP_czas_określony"},
            new ContractWrapper {Id=3,Name="UOP_czas_nieokreślony"},
            new ContractWrapper {Id=4,Name="B2B"}
            };

            SelectedContractId = 0;
        }

        private void RefreshEmployeeList()
        {
            Employees = new ObservableCollection<EmployeeWrapper>
            {
                new EmployeeWrapper
                {   Id=1,
                    FirstName="Józek",
                    LastName="Stokłosa",
                    IsCurrentlyHired=true,
                    Contract=new ContractWrapper {Id=1 } },
                new EmployeeWrapper
                {   Id=2,
                    FirstName="Wanda",
                    LastName="Dziwna",
                    IsCurrentlyHired=true,
                    Contract=new ContractWrapper {Id=2 } },
                new EmployeeWrapper
                {   Id=3,
                    FirstName="Staszek",
                    LastName="Dzik",
                    IsCurrentlyHired=true,
                    Contract=new ContractWrapper {Id=1 } }
            };
        }
    }
}
