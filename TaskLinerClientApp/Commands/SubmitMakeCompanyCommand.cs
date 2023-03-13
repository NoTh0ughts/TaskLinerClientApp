using System;
using System.ComponentModel;
using TaskLiner.DB.Entity;
using TaskLiner.DB.Entity.Views;
using TaskLinerClientApp.Stores;
using TaskLinerClientApp.ViewModels.Tabs;
using Urls;

namespace TaskLinerClientApp.Commands
{
    public class SubmitMakeCompanyCommand : CommandBase
    {
        private readonly IClientHub _client;
        private readonly Company _company;
        private readonly UserWithToken _user;
        private readonly MakeCompanyViewModel _viewModel;

        public SubmitMakeCompanyCommand(IClientHub client,
                                        Company company,
                                        UserWithToken user,
                                        MakeCompanyViewModel viewModel)
        {
            _client = client        ?? throw new ArgumentNullException();
            _company = company      ?? throw new ArgumentNullException();
            _user = user            ?? throw new ArgumentNullException();
            _viewModel = viewModel  ?? throw new ArgumentNullException();

            viewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName is (nameof(MakeCompanyViewModel.Name)) or nameof(MakeCompanyViewModel.Description))
            {
                OnCanExecutedChanged();
            }
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            var query = "api/Companies/AddCompany" .ToRelativeUrl()
                                                   .AddQueryString("user_id", _user.Id.ToString())
                                                   .AddQueryString("name", _company.Name)
                                                   .AddQueryString("description", _company.Description);

            
            _client.PostAsync(query.ToString(), _company)
                .ContinueWith(x =>
                {
                    if(x.IsCompletedSuccessfully)
                    {
                        //Todo somethng
                        throw new NotImplementedException("Я еще не сделал :(");
                    }
                });
        }
    }
}
