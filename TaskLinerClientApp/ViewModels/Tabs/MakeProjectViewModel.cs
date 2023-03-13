using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using TaskLiner.DB.Entity;
using TaskLiner.DB.Entity.Views;
using TaskLinerClientApp.Auth;
using TaskLinerClientApp.Commands;
using TaskLinerClientApp.Controls;
using TaskLinerClientApp.Stores;

namespace TaskLinerClientApp.ViewModels.Tabs
{
    public class MakeProjectViewModel : TabViewModelBase
    {
        public ICommand SubmitMakeProjectCommand { get; }
        public RelayCommand<ICloseable> CloseWindowCommand { get; }
        public UserWithToken User => _authenticator.CurrentUser;

        private readonly IAuthenticator _authenticator;
        private readonly IClientHub _client;
        private readonly Dictionary<int, string> _companies;

        private Project _project = new();

        public string Name
        {
            get => _project.Name;
            set
            {
                _project.Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string Scope
        {
            get => _project.Scope;
            set
            {
                _project.Scope = value;
                OnPropertyChanged(nameof(Scope));
            }
        }

        public string Description
        {
            get => _project.Description;
            set
            {
                _project.Description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        public string ForCompany
        {
            get
            {
                _companies.TryGetValue(_project.CompanyId, out string name);
                return name;
            }
            set => _project.CompanyId = _companies.FirstOrDefault(x => x.Value == value).Key;
        }



        public MakeProjectViewModel(IAuthenticator authenticator, IClientHub client)
        {
            _authenticator = authenticator;
            _client = client;

            CloseWindowCommand = new RelayCommand<ICloseable>(CloseWindow);
            SubmitMakeProjectCommand = new SubmitMakeProjectCommand(_client, _project, User, this);
        }

        private void Update()
        {
            /*var query = "api/Companies/AddCompany".ToRelativeUrl()
                                                  .AddQueryString("user_id", _user.Id.ToString())
                                                  .AddQueryString("name", _company.Name)
                                                  .AddQueryString("description", _company.Description);*/
        }

        private void CloseWindow(ICloseable window)
        {
            window?.Close();
        }
    }
}
