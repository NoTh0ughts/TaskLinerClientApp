using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskLinerClientApp.ViewModels.Factory
{
    public interface IViewModelFactory
    {
        ViewModelBase CreateViewModel(ViewModelType viewType);
        TabViewModelBase CreateTabViewModel(TabViewModelType tabViewType);
    }
}
