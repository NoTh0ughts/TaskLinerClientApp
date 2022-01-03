using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskLiner.DB.Entity;
using TaskLiner.DB.Entity.Views;
using TaskLinerClientApp.Stores;
using TaskLinerClientApp.ViewModels.Tabs;
using Urls;

namespace TaskLinerClientApp.Commands
{
    public class SubmitMakeProjectCommand : CommandBase
    {
        private readonly IClientHub _client;
        private readonly UserWithToken _user;
        private readonly MakeProjectViewModel _viewModel;

        private readonly Project _project = new Project();

        public SubmitMakeProjectCommand(IClientHub client,
                                        Project project,
                                        UserWithToken user,
                                        MakeProjectViewModel viewModel)
        {
            _client = client        ?? throw new ArgumentNullException();
            _project = project      ?? throw new ArgumentNullException();
            _user = user            ?? throw new ArgumentNullException();
            _viewModel = viewModel  ?? throw new ArgumentNullException();

            viewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            ///TODO
            if (true)
            {
                OnCanExecutedChanged();
            }
        }

        public override void Execute(object parameter)
        {
            /*var query = "api/Companies/AddCompany".ToRelativeUrl()
                                                   .AddQueryString("user_id", _user.Id.ToString())
                                                   .AddQueryString("name", _company.Name)
                                                   .AddQueryString("description", _company.Description);*/

            throw new NotImplementedException();
        }
    }
}
