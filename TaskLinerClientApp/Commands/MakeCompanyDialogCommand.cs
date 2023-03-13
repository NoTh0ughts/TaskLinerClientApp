using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Effects;
using TaskLinerClientApp.Auth;
using TaskLinerClientApp.ViewModels.Factory;
using TaskLinerClientApp.ViewModels.Tabs;

namespace TaskLinerClientApp.Commands
{
    public class MakeCompanyDialogCommand : CommandBase
    {
        private readonly IAuthenticator _authenticator;
        private readonly CompaniesTabViewModel companiesTabViewModel;
        private readonly IViewModelFactory viewModelFactory;

        public MakeCompanyDialogCommand(IAuthenticator authenticator, CompaniesTabViewModel companiesTabViewModel, IViewModelFactory viewModelFactory)
        {
            _authenticator = authenticator ?? throw new ArgumentNullException();
            this.companiesTabViewModel = companiesTabViewModel;
            this.viewModelFactory = viewModelFactory;
        }

        public override bool CanExecute(object parameter)
        {
            return _authenticator.IsLoggedIn;
        }

        public override void Execute(object parameter)
        {
            companiesTabViewModel.DialogShowed.Invoke();

            var dialogWindow = new MakeCompanyWindow();
            dialogWindow.DataContext = viewModelFactory.CreateTabViewModel(TabViewModelType.MakeCompany);
            dialogWindow.ShowDialog();

            companiesTabViewModel.DialogClosed.Invoke();
        }
    }
}
