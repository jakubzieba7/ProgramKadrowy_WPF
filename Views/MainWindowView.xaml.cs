using MahApps.Metro.Controls;
using ProgramKadrowy_WPF.ViewModels;

namespace ProgramKadrowy_WPF.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindowView : MetroWindow
    {
        public MainWindowView()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
    }
}
