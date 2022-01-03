using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskLinerClientApp.ViewModels.Factory
{
    public delegate TViewModel CreateTabViewModel<TViewModel>() where TViewModel : TabViewModelBase;
}
