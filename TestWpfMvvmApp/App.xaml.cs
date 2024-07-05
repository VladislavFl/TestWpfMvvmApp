using System.Windows;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using TestWpfMvvmApp.Services;
using TestWpfMvvmApp.ViewModel;
using TestWpfMvvmApp.Services.Interfaces;
using TestWpfMvvmApp.View;

namespace TestWpfMvvmApp
{
    public partial class App : Application
    {
        public static IHost? AppHost { get; private set; }

        public App()
        {
            AppHost = Host.CreateDefaultBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton(s => new MainWindow
                    {
                        DataContext = s.GetRequiredService<NavigationViewModel>(),
                    });
                    services.AddSingleton(s => new AuthView
                    {
                        DataContext = s.GetRequiredService<AuthViewModel>(),
                    });
                    services.AddSingleton(s => new InfoView
                    {
                        DataContext = s.GetRequiredService<InfoViewModel>(),
                    });
                    services.AddSingleton(s => new UserView
                    {
                        DataContext = s.GetRequiredService<UserViewModel>(),
                    });

                    services.AddSingleton<NavigationViewModel>();
                    services.AddSingleton<AuthViewModel>();
                    services.AddSingleton<IAuthStateService, AuthStateService>();
                })
                .Build();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await AppHost!.StartAsync();

            var startupForm = AppHost.Services.GetRequiredService<MainWindow>();
            startupForm.Show();

            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await AppHost!.StopAsync();
            base.OnExit(e);
        }
    }
}
