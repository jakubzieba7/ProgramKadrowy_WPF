using MahApps.Metro.Controls;
using ProgramKadrowy_WPF.Models.Wrappers;
using ProgramKadrowy_WPF.ViewModels;

namespace ProgramKadrowy_WPF.Views
{
    /// <summary>
    /// Interaction logic for AddEmployee.xaml
    /// </summary>
    public partial class AddEditEmployeeView : MetroWindow
    {
        public AddEditEmployeeView(EmployeeWrapper employee = null)
        {
            InitializeComponent();
            DataContext = new AddEditEmployeeViewModel(employee);
        }
    }
}
