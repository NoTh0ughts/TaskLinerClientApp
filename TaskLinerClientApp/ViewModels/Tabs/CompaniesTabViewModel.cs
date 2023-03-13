using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Effects;
using TaskLiner.DB.Entity.Views;
using TaskLinerClientApp.Auth;
using TaskLinerClientApp.Commands;
using TaskLinerClientApp.Stores;
using TaskLinerClientApp.ViewModels.Factory;

namespace TaskLinerClientApp.ViewModels.Tabs
{
    public class CompaniesTabViewModel : TabViewModelBase
    {
        public ObservableCollection<CompanyResource> Companies => new (_companies);
        public IEnumerable<CompanyResource> _companies = new List<CompanyResource>();
        public ICommand MakeCompanyDialogCommand { get; }

        public Action DialogShowed;
        public Action DialogClosed;

        private readonly IClientHub _clientHub;
        private readonly IAuthenticator _authenticator;

        public CompaniesTabViewModel(IClientHub clientHub, 
                                     IAuthenticator authenticator, 
                                     IViewModelFactory viewModelFactory)
        {
            DialogShowed += OnDialogShowed;
            DialogClosed += OnDialogClosed;

            _clientHub = clientHub;
            _authenticator = authenticator;

            UpdateCompanies();

            MakeCompanyDialogCommand = new MakeCompanyDialogCommand(_authenticator, this, viewModelFactory);
        }

        private void UpdateCompanies()
        {
            _ = _clientHub.GetResourceAsync<ICollection<CompanyResource>>($"api/Companies/user?id={_authenticator.CurrentUser.Id}")
               .ContinueWith(result =>
               {
                   _companies = result.Result;
                   OnPropertyChanged(nameof(Companies));
               });
        }

        private void OnDialogShowed()
        {
            Application.Current.MainWindow.Effect = new BlurEffect();
        }

        private void OnDialogClosed()
        {
            Application.Current.MainWindow.Effect = null;
            UpdateCompanies();
        }
    }
}
