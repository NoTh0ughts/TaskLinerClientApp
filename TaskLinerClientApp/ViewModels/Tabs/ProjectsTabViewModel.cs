using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskLiner.DB.Entity;
using TaskLinerClientApp.Auth;
using TaskLinerClientApp.Stores;

namespace TaskLinerClientApp.ViewModels.Tabs
{
    public class ProjectsTabViewModel : TabViewModelBase
    {
        public ObservableCollection<Project> Projects { get; private set; }

        private readonly IClientHub _clientHub;
        private readonly IAuthenticator _authenticator;

        public ProjectsTabViewModel(IClientHub clientHub, IAuthenticator authenticator)
        {
            _clientHub = clientHub;
            _authenticator = authenticator;

            UpdateProjects();
        }

        public void UpdateProjects()
        {
            _ = _clientHub.GetResourceAsync<ICollection<Project>>($"api/projects/user/{_authenticator.CurrentUser.Id}")
                .ContinueWith(
                x =>
                {
                    if (x.IsCompletedSuccessfully)
                    {
                        Projects = new ObservableCollection<Project>(x.Result);
                        OnPropertyChanged(nameof(Projects));
                    }
                }
                );
        }
        
    }
}
