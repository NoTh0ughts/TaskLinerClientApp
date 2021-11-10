using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using TaskLinerClientApp.Auth;
using TaskLinerClientApp.ViewModels;

namespace TaskLinerClientApp
{
    public partial class App : Application
    {
        private ServiceProvider serviceProvider;

        public App()
        {
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            serviceProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new AuthWindow()
            {
                DataContext = new AuthViewModel(serviceProvider.GetService<IAuthenticationService>())
            };
            MainWindow.Show();

            base.OnStartup(e);
        }

        private void ConfigureServices(ServiceCollection services)
        {
            services.AddSingleton<IAuthenticationService, TokenAuthenticationService>();
            services.AddSingleton<IAuthenticator, Authenticator>();
            
        }
    }
}