using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Controls;
using ProgramKadrowy_WPF.Properties;
using ProgramKadrowy_WPF.Views;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows;

namespace ProgramKadrowy_WPF
{
    public class SQLConnectionHelper
    {

        public bool IsSQLConnectionSuccessful()
        {
            try
            {
                using (var context = new ApplicationDBContext())
                {
                    context.Database.Connection.Open();
                    context.Database.Connection.Close();
                }
                return true;
            }
            catch (SqlException)
            {
                //EditSQLConnectionDataAsync();
                return false;
            }
        }

        public void TestSQLConnection()
        {
            try
            {
                using (var context = new ApplicationDBContext())
                {
                    context.Database.Connection.Open();
                    context.Database.Connection.Close();
                }
            }
            catch (SqlException)
            {
                EditSQLConnectionData();
            }
            SQLConnectionSuccessMsg(); 
        }

        public async Task EditSQLConnectionDataAsync()
        {
            var metroWindow = Application.Current.MainWindow as MetroWindow;
            var dialog = await metroWindow.ShowMessageAsync("Niewłaściwe dane do połączenia z bazą SQL", "Czy chcesz edytować dane do połączenia z bazą SQL?", MessageDialogStyle.AffirmativeAndNegative);

            if (dialog == MessageDialogResult.Affirmative)
            {
                var addEditSQLSettingsWindow = new SQLSettingsView(false);
                addEditSQLSettingsWindow.ShowDialog();
            }
            else
                Application.Current.Shutdown();
        }

        public void EditSQLConnectionData()
        {
            var metroWindow = Application.Current.MainWindow as MetroWindow;
            var dialog = metroWindow.ShowModalMessageExternal("Niewłaściwe dane do połączenia z bazą SQL", "Czy chcesz edytować dane do połączenia z bazą SQL?", MessageDialogStyle.AffirmativeAndNegative);
            
            if (dialog == MessageDialogResult.Affirmative)
            {
                CloseAllWindows();
                var addEditSQLSettingsWindow = new SQLSettingsView(true);
                addEditSQLSettingsWindow.ShowDialog();
            }
            else
                Application.Current.MainWindow.Close();
        }

        private void CloseAllWindows()
        {
            for (int intCounter = App.Current.Windows.Count - 1; intCounter > 0; intCounter--)
                App.Current.Windows[intCounter].Close();
        }

        public void SQLConnectionSuccessMsg()
        {
            var metroWindow = Application.Current.MainWindow as MetroWindow;
            metroWindow.ShowModalMessageExternal("Połaczenie z bazą danych SQL", $"Test połączenia z bazą danych {Settings.Default.SQLDatabaseName} przebiegł pomyślnie.", MessageDialogStyle.Affirmative);
        }
    }
}