using System.ComponentModel;
using System.Windows;
using TaskLinerClientApp.Auth;
using TaskLinerClientApp.Models;
using TaskLinerClientApp.Stores;
using TaskLinerClientApp.ViewModels;

namespace TaskLinerClientApp.Commands
{
    public class AuthCommand : CommandBase
    {
        public IAuthenticator Authenticator { get; }
        public AuthViewModel AuthViewModel { get; set; }

        private readonly IRenavigator _navigator;

        public AuthCommand(IAuthenticator service,
                           AuthViewModel authViewModel,
                           IRenavigator navigateStore)
        {
            _navigator = navigateStore;
            Authenticator = service;
            AuthViewModel = authViewModel;
            AuthViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName is (nameof(AuthViewModel.Username)) or
                (nameof(AuthViewModel.Password)))
            {
                OnCanExecutedChanged();
            }
        }

        public override void Execute(object parameter)
        {
            _ = Authenticator.Login(new UserIdentityModel()
            {
                Username = AuthViewModel.Username,
                Password = "1234"
            }).ContinueWith(x =>
            {
                if (x.Result == null)
                {
                    MessageBox.Show("Unsuccess");
                    AuthViewModel.OnUnsuccessfulLogin();
                }
                else
                {
                    MessageBox.Show("Success");
                    _navigator.Renavigate();
                    AuthViewModel.OnSuccessLogin();
                }
            });

            AuthViewModel.OnLoginProcess();
        }
    }
}
