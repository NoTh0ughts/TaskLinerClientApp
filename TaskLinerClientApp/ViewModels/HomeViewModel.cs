using System.Collections.Generic;
using System.Windows.Input;
using TaskLiner.DB.Entity;
using TaskLiner.DB.Entity.Views;
using TaskLinerClientApp.Auth;
using TaskLinerClientApp.Commands;
using TaskLinerClientApp.Stores;
using TaskLinerClientApp.ViewModels.Factory;

namespace TaskLinerClientApp.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public IAuthenticationService AuthenticationService { get; }
        public IAuthenticator Authenticator { get; }
        

        public User CurrentUser => Authenticator.CurrentUser;

        private readonly IViewModelFactory _viewModelFactory;
        private readonly ITabNavigationStore _tabNavigationStore;

        public TabViewModelBase CurrentTabViewModel => 
            _tabNavigationStore.CurrentTabViewModel;

        public ICommand UpdateCurrentTabViewModel { get; }

        public HomeViewModel(IAuthenticationService authenticationService,
                             IViewModelFactory viewModelFactory,
                             ITabNavigationStore tabNavigationStore,
                             IAuthenticator authenticator)
        {
            AuthenticationService = authenticationService;
            Authenticator = authenticator;
            _viewModelFactory = viewModelFactory;
            _tabNavigationStore = tabNavigationStore;

            _tabNavigationStore.CurrentViewModelChanged += OnCurrentTabViewModelChanged;

            UpdateCurrentTabViewModel =
                new UpdateCurrentTabViewModelCommand(_viewModelFactory, _tabNavigationStore);
            UpdateCurrentTabViewModel.Execute(TabViewModelType.Home);
        }

        private void OnCurrentTabViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentTabViewModel));
        }
    }
}
