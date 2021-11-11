using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using TaskLinerClientApp.ViewModels;

namespace TaskLinerClientApp.Host_Extensions
{
    public static class AddViewsBuilderExtension
    {
        public static ServiceCollection AddViews(this ServiceCollection services)
        {
            services.AddSingleton(
                s => new MainWindow(s.GetRequiredService<MainViewModel>()));
            return services;
        }
    }
}
