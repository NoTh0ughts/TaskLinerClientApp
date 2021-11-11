using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TaskLinerClientApp.Auth;
using TaskLinerClientApp.Stores;
using TaskLinerClientApp.ViewModels;
using TaskLinerClientApp.ViewModels.Factory;

namespace TaskLinerClientApp.Host_Extensions
{
    public static class AddViewModelsBuilderExtension
    {
        public static ServiceCollection AddViewModels(this ServiceCollection services)
        {
            services.AddTransient(CreateAuthViewModel)
                    .AddTransient(CreateHomeViewModel)
                    .AddTransient<MainViewModel>();



            services.AddSingleton<CreateViewModel<AuthViewModel>>
                        (services => () => services.GetRequiredService<AuthViewModel>())
                    .AddSingleton<CreateViewModel<HomeViewModel>>
                        (services => () => services.GetRequiredService<HomeViewModel>());

            services.AddSingleton<IViewModelFactory, ViewModelFactory>();

            services.AddSingleton<ViewModelRenavigator<AuthViewModel>>()
                    .AddSingleton<ViewModelRenavigator<HomeViewModel>>();

            return services;
        }

        private static AuthViewModel CreateAuthViewModel(IServiceProvider services)
        {
            return new AuthViewModel(
                services.GetRequiredService<IAuthenticationService>(),
                services.GetRequiredService<ViewModelRenavigator<HomeViewModel>>()
                );
        }

        private static HomeViewModel CreateHomeViewModel(IServiceProvider services)
        {
            return new HomeViewModel();
        }
    }
}
