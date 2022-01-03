using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskLinerClientApp.ViewModels;

namespace TaskLinerClientApp.Stores
{
    public class TabNavigationStore : ITabNavigationStore
    {
        private TabViewModelBase _currentTabViewModel;

        public TabViewModelBase CurrentTabViewModel
        {
            get => _currentTabViewModel;
            set
            {
                _currentTabViewModel = value;
                OnCurrentViewModelChanged();
            }
        }


        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }

        public event Action CurrentViewModelChanged;
    }
}
