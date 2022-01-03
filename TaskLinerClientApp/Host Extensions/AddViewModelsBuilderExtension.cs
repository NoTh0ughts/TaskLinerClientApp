using System;
using Microsoft.Extensions.DependencyInjection;
using TaskLinerClientApp.Auth;
using TaskLinerClientApp.Stores;
using TaskLinerClientApp.ViewModels;
using TaskLinerClientApp.ViewModels.Factory;
using TaskLinerClientApp.ViewModels.Tabs;
using TaskLinerClientApp.ViewModels.Widgets;

namespace TaskLinerClientApp.Host_Extensions
{
    public static class AddViewModelsBuilderExtension
    {
        public static ServiceCollection AddViewModels(this ServiceCollection services)
        {
            services.AddTransient(CreateAuthViewModel)
                    .AddTransient(CreateHomeViewModel)
                    .AddTransient<MainViewModel>()
                    .AddTransient<HomeTabViewModel>()
                    .AddTransient<CompaniesTabViewModel>()
                    .AddTransient<ProjectsTabViewModel>()
                    .AddTransient<MakeCompanyViewModel>()
                    .AddTransient<TimerHomeWidgetViewModel>();


            _ = services.AddSingleton<CreateViewModel<AuthViewModel>>
                        (services => () => services.GetRequiredService<AuthViewModel>())
                    .AddSingleton<CreateViewModel<HomeViewModel>>
                        (services => () => services.GetRequiredService<HomeViewModel>())
                    .AddSingleton<CreateTabViewModel<HomeTabViewModel>>
                        (services => () => services.GetRequiredService<HomeTabViewModel>())
                    .AddSingleton<CreateTabViewModel<ProjectsTabViewModel>>
                        (services => () => services.GetRequiredService<ProjectsTabViewModel>())
                    .AddSingleton<CreateTabViewModel<CompaniesTabViewModel>>
                        (services => () => services.GetRequiredService<CompaniesTabViewModel>())
                    .AddSingleton<CreateTabViewModel<MakeCompanyViewModel>>
                        (services => () => services.GetRequiredService<MakeCompanyViewModel>());


            services.AddSingleton<IViewModelFactory, ViewModelFactory>();
            services.AddSingleton<ViewModelRenavigator<AuthViewModel>>()
                    .AddSingleton<ViewModelRenavigator<HomeViewModel>>();

            return services;
        }

        private static AuthViewModel CreateAuthViewModel(IServiceProvider services)
        {
            return new AuthViewModel(
                services.GetRequiredService<IAuthenticator>(),
                services.GetRequiredService<ViewModelRenavigator<HomeViewModel>>());
        }

        private static HomeViewModel CreateHomeViewModel(IServiceProvider services)
        {
            return new HomeViewModel(
                services.GetRequiredService<IAuthenticationService>(),
                services.GetRequiredService<IViewModelFactory>(),
                services.GetRequiredService<ITabNavigationStore>(),
                services.GetRequiredService<IAuthenticator>());
        }
    }
}
