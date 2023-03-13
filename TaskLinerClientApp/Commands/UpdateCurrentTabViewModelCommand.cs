using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskLinerClientApp.Stores;
using TaskLinerClientApp.ViewModels.Factory;

namespace TaskLinerClientApp.Commands
{ 
    class UpdateCurrentTabViewModelCommand : CommandBase
    {
        public event EventHandler CanExecuteChanged;

        private readonly ITabNavigationStore _navigator;
        private readonly IViewModelFactory _viewModelFactory;

        public UpdateCurrentTabViewModelCommand(IViewModelFactory viewModelFactory,
                                                ITabNavigationStore navigator)
        {
            _viewModelFactory = viewModelFactory;
            _navigator = navigator;
        }

        public override void Execute(object parameter)
        {
            if (parameter is TabViewModelType viewType)
            {
                _navigator.CurrentTabViewModel = _viewModelFactory.CreateTabViewModel(viewType);
            }
        }
    }
}
