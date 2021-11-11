using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using TaskLinerClientApp.Auth;

namespace TaskLinerClientApp.ViewModels.Factory
{
    public enum ViewModelType
    {
        Auth,
        Home
    }

    public class ViewModelFactory : IViewModelFactory
    {
        public readonly CreateViewModel<AuthViewModel> _createAuthViewModel;
        public readonly CreateViewModel<HomeViewModel> _createHomeViewModel;


        public ViewModelFactory(CreateViewModel<AuthViewModel> createAuthViewModel, 
                                CreateViewModel<HomeViewModel> createHomeViewModel)
        {
            _createAuthViewModel = createAuthViewModel;
            _createHomeViewModel = createHomeViewModel;
        }


        public ViewModelBase CreateViewModel(ViewModelType viewType)
        {
            return viewType switch
            {
                ViewModelType.Auth => _createAuthViewModel(),
                ViewModelType.Home => _createHomeViewModel(),
                _ => new ViewModelBase(),
            };
        }
    }
}