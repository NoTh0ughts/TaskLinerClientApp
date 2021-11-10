using System.ComponentModel;
using System.Windows;
using TaskLinerClientApp.Auth;
using TaskLinerClientApp.Models;
using TaskLinerClientApp.ViewModels;

namespace TaskLinerClientApp.Commands
{
    public class AuthCommand : CommandBase
    {
        public IAuthenticationService Service { get; }
        public AuthViewModel AuthViewModel { get; set; } 

        public AuthCommand(IAuthenticationService service, AuthViewModel authViewModel)
        {
            Service = service;
            AuthViewModel = authViewModel;
            AuthViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(AuthViewModel.Username) || e.PropertyName == nameof(AuthViewModel.Password))
            {
                OnCanExecutedChanged();
            }
        }

        public override void Execute(object parameter)
        {
            _ = Service.Login(new UserIdentityModel()
            {
                Username = AuthViewModel.Username,
                Password = "1234"
            }).ContinueWith(x =>
            {
                if (x.Result == false)
                {
                    AuthViewModel.OnUnsuccessfulLogin();
                }
                else
                {
                    AuthViewModel.OnSuccessLogin();
                }
            });

            AuthViewModel.OnLoginProcess();
        }
    }
}
