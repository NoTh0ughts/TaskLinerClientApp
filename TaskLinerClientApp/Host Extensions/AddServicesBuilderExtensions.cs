using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using RestClient.Net;
using TaskLinerClientApp.Auth;
using TaskLinerClientApp.Stores;
using Urls;

namespace TaskLinerClientApp.Host_Extensions
{
    public static class AddServicesBuilderExtensions
    {
        public static ServiceCollection AddServices(this ServiceCollection services)
        {
            services.AddSingleton<ITabNavigationStore, TabNavigationStore>();
            services.AddSingleton<IAuthenticationService, TokenAuthenticationService>();
            services.AddSingleton<IAuthenticator, Authenticator>();
            services.AddSingleton<INavigationStore, NavigationStore>();
            services.AddSingleton<IClientHub, ClientHub>();
            services.AddSingleton<WorkingTimer>();
            services.AddRestClient(o => o.BaseUrl = "https://localhost:5001/Api".ToAbsoluteUrl());

            services.AddHttpClient();

            return services;
        }
    }
}
