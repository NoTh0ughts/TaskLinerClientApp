using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using TaskLinerClientApp.Auth;
using TaskLinerClientApp.Host_Extensions;
using TaskLinerClientApp.ViewModels;

namespace TaskLinerClientApp
{
    public partial class App : Application
    {
        private readonly ServiceProvider serviceProvider;

        public App()
        {
            ServiceCollection services = new();
            ConfigureServices(services);
            serviceProvider = services.BuildServiceProvider();
            TimeService.Initialize();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            Window window = serviceProvider.GetRequiredService<MainWindow>();
            window.Show();

            base.OnStartup(e);
        }

        private void ConfigureServices(ServiceCollection services)
        {
            services.AddSingleton<MainWindow>();

            services.AddServices()
                    .AddViewModels()
                    .AddViews();
        }
    }
}