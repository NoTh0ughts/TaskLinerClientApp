using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using TaskLinerClientApp.Auth;
using TaskLinerClientApp.Stores;

namespace TaskLinerClientApp.Host_Extensions
{
    public static class AddServicesBuilderExtensions
    {
        public static ServiceCollection AddServices(this ServiceCollection services)
        {
            services.AddSingleton<IAuthenticationService, TokenAuthenticationService>();
            services.AddSingleton<IAuthenticator, Authenticator>();
            services.AddSingleton<INavigationStore, NavigationStore>();
            return services;
        }
    }
}
