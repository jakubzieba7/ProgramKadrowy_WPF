using ProgramKadrowy_WPF.Commands;
using ProgramKadrowy_WPF.Properties;
using ProgramKadrowy_WPF.Views;
using System;
using System.Collections.Generic;
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
        }
        
        public ICommand SQLSettingsCommand { get; set; }
        public ICommand RefreshEmployeeCommand { get; set; }
        public ICommand EditEmployeeCommand { get; set; }
        public ICommand AddEmployeeCommand { get; set; }

        private void AddEditEmployeeData(object obj)
        {
            throw new NotImplementedException();
        }
        private bool CanEditEmployeeData(object obj)
        {
            return true;
        }
        private void RefreshEmployeeData(object obj)
        {
            throw new NotImplementedException();
        }
        private void AddEditSQLSettings(object obj)
        {
            var addEditSQLSettingsWindow = new SQLSettingsView();
            addEditSQLSettingsWindow.Closed += AddEditSQLSettingsWindow_Closed;
            addEditSQLSettingsWindow.ShowDialog();
        }

        private void AddEditSQLSettingsWindow_Closed(object sender, EventArgs e)
        {
            Settings.Default.Save();
        }
    }
}
