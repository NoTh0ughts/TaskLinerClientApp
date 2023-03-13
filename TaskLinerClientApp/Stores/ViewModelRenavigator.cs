using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskLinerClientApp.ViewModels;
using TaskLinerClientApp.ViewModels.Factory;

namespace TaskLinerClientApp.Stores
{
    class ViewModelRenavigator<TViewModel> : IRenavigator where TViewModel : ViewModelBase
    {
        private readonly INavigationStore _navigator;
        private readonly CreateViewModel<TViewModel> _createViewModel;

        public ViewModelRenavigator(INavigationStore navigator, CreateViewModel<TViewModel> createViewModel)
        {
            _navigator = navigator;
            _createViewModel = createViewModel;
        }

        public void Renavigate()
        {
            _navigator.CurrentTabViewModel = _createViewModel();
        }
    }
}
