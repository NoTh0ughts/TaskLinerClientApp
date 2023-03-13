using System;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using TaskLiner.DB.Entity;
using TaskLiner.DB.Entity.Views;
using TaskLinerClientApp.Auth;
using TaskLinerClientApp.Commands;
using TaskLinerClientApp.Controls;
using TaskLinerClientApp.Stores;

namespace TaskLinerClientApp.ViewModels.Tabs
{
    public class MakeCompanyViewModel : TabViewModelBase
    {
        public ICommand SubmitMakeCompanyCommand { get; }
        public RelayCommand<ICloseable> CloseWindowCommand { get; }
        public UserWithToken User => _authenticator.CurrentUser;


        public string Name
        {
            get => _company.Name;
            set
            {
                _company.Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string Description
        {
            get => _company.Description;
            set
            {
                _company.Description = value;
                OnPropertyChanged(nameof(Description));
            }
        }


        private Company _company = new Company();

        private readonly IAuthenticator _authenticator;
        private readonly IClientHub _client;


        public MakeCompanyViewModel(IAuthenticator authenticator, IClientHub client)
        {
            _authenticator = authenticator ?? throw new ArgumentNullException();
            _client = client;
            SubmitMakeCompanyCommand = new SubmitMakeCompanyCommand(_client, _company, User, this);
            CloseWindowCommand = new RelayCommand<ICloseable>(CloseWindow);
        }

        private void CloseWindow(ICloseable window)
        {
            window?.Close();
        }
    }
}
