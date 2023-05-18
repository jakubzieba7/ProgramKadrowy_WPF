using ProgramKadrowy_WPF.Commands;
using ProgramKadrowy_WPF.Properties;
using System;
using System.Security;
using System.Windows.Input;
using System.Windows;
using System.Runtime.InteropServices;

namespace ProgramKadrowy_WPF.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        public LoginViewModel()
        {
            LogInCommand = new RelayCommand(LogIn);
            CreateAccountCommand = new RelayCommand(CreateAccount);
        }

        public SecureString SecurePassword { private get; set; }

        private string _appUsername;
        public string AppUsername
        {
            get
            {
                return _appUsername;
            }
            set
            {
                _appUsername = value;
                OnPropertyChanged();
            }
        }

        public ICommand LogInCommand { get; set; }
        public ICommand CreateAccountCommand { get; set; }
        private void CreateAccount(object obj)
        {
            CreateAccountMsg();
        }

        private string SecureStringToString(SecureString value)
        {
            IntPtr valuePtr = IntPtr.Zero;
            try
            {
                valuePtr = Marshal.SecureStringToGlobalAllocUnicode(value);
                return Marshal.PtrToStringUni(valuePtr);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(valuePtr);
            }
        }

        private void LogIn(object obj)
        {
            if (AppUsername != Settings.Default.AppUserName || SecureStringToString(SecurePassword) != Settings.Default.AppPassword)
                EditUserCredentialsTraditional();
            else
            {
                LoginCredentialsSuccessMsg();
                CloseAllWindows();
            }
        }

        private void CloseAllWindows()
        {
            for (int intCounter = App.Current.Windows.Count - 1; intCounter > 0; intCounter--)
                App.Current.Windows[intCounter].Close();
        }


        private void EditUserCredentialsTraditional()
        {
            var dialog = MessageBox.Show("Czy chcesz edytować dane logowania do aplikacji?", "Podano niewłaściwe dane logowania", MessageBoxButton.YesNo);

            if (dialog == MessageBoxResult.Yes)
                return;
            else
                Application.Current.Shutdown();
        }

        private void LoginCredentialsSuccessMsg()
        {
            MessageBox.Show($"Dane logowania do aplikacji dla użytkownika {Settings.Default.AppUserName} są prawidłowe.", "Dane logowania do aplikacji", MessageBoxButton.OK);
        }

        private void CreateAccountMsg()
        {
            MessageBox.Show("Jeśli nie posiadasz konta użytkownika, utwórz nowe.", "Konto użytkownika", MessageBoxButton.OK);
        }

    }
}
