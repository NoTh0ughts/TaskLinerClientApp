using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskLinerClientApp.ViewModels;

namespace TaskLinerClientApp.Stores
{
    public interface ITabNavigationStore
    {
        public TabViewModelBase CurrentTabViewModel { get; set; }

        public event Action CurrentViewModelChanged;
    }
}
