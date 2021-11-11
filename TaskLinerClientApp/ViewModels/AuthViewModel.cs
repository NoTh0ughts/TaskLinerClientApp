using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TaskLinerClientApp.Auth;
using TaskLinerClientApp.Commands;
using TaskLinerClientApp.Stores;

namespace TaskLinerClientApp.ViewModels
{
    public class AuthViewModel : ViewModelBase
    {
        #region Notifybale props
        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        private string _username;


        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        private string _password;
        
        public Visibility LoginButton
        {
            get => _loginButton;
            set
            {
                _loginButton = value;
                OnPropertyChanged(nameof(LoginButton));
            }
        }
        private Visibility _loginButton = Visibility.Visible;

        
        public Visibility LoginIndicator
        {
            get => _loginIndicator;
            set
            {
                _loginIndicator = value;
                OnPropertyChanged(nameof(LoginIndicator));
            }
        }
        private Visibility _loginIndicator { get; set; } = Visibility.Collapsed;

        public Visibility WrongIdentityText
        {
            get => _wrongIdentityText;
            set
            {
                _wrongIdentityText = value;
                OnPropertyChanged(nameof(WrongIdentityText));
            }
        }
        private Visibility _wrongIdentityText { get; set; } = Visibility.Hidden;
        #endregion

        public ICommand AuthCommand { get; }
        public ICommand RegisterCommand { get; }


        public AuthViewModel(IAuthenticationService authenticationService, IRenavigator navigateStore)
        {
            AuthCommand = new AuthCommand(authenticationService, authViewModel: this, navigateStore);
        }

        public void OnUnsuccessfulLogin()
        {
            OnLoginProcessEnd();
            WrongIdentityText = Visibility.Visible;
            //MessageBox.Show("Unsuccess");

        }

        public void OnSuccessLogin()
        {
            OnLoginProcessEnd();
            //MessageBox.Show("Success");
        }

        public void OnLoginProcess()
        {
            //MessageBox.Show("Login process");
            LoginButton = Visibility.Collapsed;
            LoginIndicator = Visibility.Visible;

        }

        public void OnLoginProcessEnd()
        {
            LoginButton = Visibility.Visible;
            LoginIndicator = Visibility.Collapsed;
        }
        
    }
}
