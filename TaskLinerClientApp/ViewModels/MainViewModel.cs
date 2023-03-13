using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TaskLinerClientApp.Auth;
using TaskLinerClientApp.Commands;
using TaskLinerClientApp.Stores;
using TaskLinerClientApp.ViewModels.Factory;

namespace TaskLinerClientApp.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IViewModelFactory _viewModelFactory;
        private readonly INavigationStore _navigationStore;

        public ViewModelBase CurrentViewModel => _navigationStore.CurrentTabViewModel;
        public IAuthenticator Authenticator { get; }

        public bool IsLoggedIn => Authenticator.IsLoggedIn;
        public ICommand UpdateCurrentViewModelCommand { get; }

        
        public MainViewModel(IAuthenticator authenticator,
                             INavigationStore navigationStore,
                             IViewModelFactory viewModelFactory)
        {
            Authenticator = authenticator;

            _navigationStore = navigationStore;
            _viewModelFactory = viewModelFactory;

            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;

            UpdateCurrentViewModelCommand =
                new UpdateCurrentViewModelCommand(_viewModelFactory, navigationStore);
            UpdateCurrentViewModelCommand.Execute(ViewModelType.Auth);
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
