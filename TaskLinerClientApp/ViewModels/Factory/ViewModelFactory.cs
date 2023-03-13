using TaskLinerClientApp.ViewModels.Tabs;

namespace TaskLinerClientApp.ViewModels.Factory
{
    public enum ViewModelType
    {
        Auth,
        Home
    }

    public enum TabViewModelType
    {
        Home,
        Projects,
        Companies,
        MakeCompany
    }

    public class ViewModelFactory : IViewModelFactory
    {
        private readonly CreateViewModel<AuthViewModel> _createAuthViewModel;
        private readonly CreateViewModel<HomeViewModel> _createHomeViewModel;

        private readonly CreateTabViewModel<HomeTabViewModel> _createHomeTabViewModel;
        private readonly CreateTabViewModel<ProjectsTabViewModel> _createProjectsTabViewModel;
        private readonly CreateTabViewModel<CompaniesTabViewModel> _createCompaniesTabViewModel;
        private readonly CreateTabViewModel<MakeCompanyViewModel> _createMakeCompanyViewModel;
        public ViewModelFactory(CreateViewModel<AuthViewModel> createAuthViewModel,
                                CreateViewModel<HomeViewModel> createHomeViewModel,
                                CreateTabViewModel<HomeTabViewModel> createTabViewModel,
                                CreateTabViewModel<ProjectsTabViewModel> createProjectsTabViewModel,
                                CreateTabViewModel<CompaniesTabViewModel> createCompaniesTabViewModel, 
                                CreateTabViewModel<MakeCompanyViewModel> createMakeCompanyViewModel)
        {
            _createAuthViewModel = createAuthViewModel;
            _createHomeViewModel = createHomeViewModel;
            _createHomeTabViewModel = createTabViewModel;
            _createProjectsTabViewModel = createProjectsTabViewModel;
            _createCompaniesTabViewModel = createCompaniesTabViewModel;
            _createMakeCompanyViewModel = createMakeCompanyViewModel;
        }


        public ViewModelBase CreateViewModel(ViewModelType viewType)
        {
            return viewType switch
            {
                ViewModelType.Auth => _createAuthViewModel(),
                ViewModelType.Home => _createHomeViewModel(),
                _ => new ViewModelBase(),
            };
        }

        public TabViewModelBase CreateTabViewModel(TabViewModelType tabViewType)
        {
            return tabViewType switch
            {
                TabViewModelType.Home => _createHomeTabViewModel(),
                TabViewModelType.Projects => _createProjectsTabViewModel(),
                TabViewModelType.Companies => _createCompaniesTabViewModel(),
                TabViewModelType.MakeCompany => _createMakeCompanyViewModel(),
                _ => new TabViewModelBase(),
            };
        }
    }
}