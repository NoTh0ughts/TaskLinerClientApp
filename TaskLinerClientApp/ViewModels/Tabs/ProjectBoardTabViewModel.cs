using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskLinerClientApp.Auth;
using TaskLinerClientApp.Stores;

namespace TaskLinerClientApp.ViewModels.Tabs
{
    public class ProjectBoardTabViewModel : TabViewModelBase
    {
        private readonly IClientHub _clientHub;
        private readonly IAuthenticator _authenticator;
        public ProjectBoardTabViewModel(IClientHub clientHub, IAuthenticator authenticator)
        {
            _clientHub = clientHub;
            _authenticator = authenticator;
        }


    }
}
