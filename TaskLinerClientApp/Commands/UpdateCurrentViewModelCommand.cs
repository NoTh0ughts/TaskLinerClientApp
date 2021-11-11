using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskLinerClientApp.Stores;
using TaskLinerClientApp.ViewModels.Factory;

namespace TaskLinerClientApp.Commands
{
    public class UpdateCurrentViewModelCommand : CommandBase
    {
        public event EventHandler CanExecuteChanged;

        private readonly INavigationStore _navigator;
        private readonly IViewModelFactory _viewModelFactory;

        public UpdateCurrentViewModelCommand(IViewModelFactory viewModelFactory,
                                             INavigationStore navigator)
        {
            _viewModelFactory = viewModelFactory;
            _navigator = navigator;
        }
        

        public override void Execute(object parameter)
        {
            if (parameter is ViewModelType viewType)
            {
                _navigator.CurrentViewModel = _viewModelFactory.CreateViewModel(viewType);
            }
        }
    }
}
