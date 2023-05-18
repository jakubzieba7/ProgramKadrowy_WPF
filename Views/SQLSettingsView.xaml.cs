using MahApps.Metro.Controls;
using ProgramKadrowy_WPF.ViewModels;

namespace ProgramKadrowy_WPF.Views
{
    /// <summary>
    /// Interaction logic for SQLSettingsView.xaml
    /// </summary>
    public partial class SQLSettingsView : MetroWindow
    {
        public SQLSettingsView(bool canCloseWindow)
        {
            InitializeComponent();
            DataContext = new SQLSettingsViewModel(canCloseWindow);
        }
    }
}
