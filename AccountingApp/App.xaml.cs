using AccountingApp.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;

namespace AccountingApp
{
    public partial class App : Application
    {
        public static IHost? AppHost { get; private set; }
        
        public App() {
            AppHost = Host.CreateDefaultBuilder()
                .ConfigureServices((hostContext,  services) =>
                {
                    services.AddSingleton<MainWindow>();
                    services.AddTransient<AppDbContext>();
                }).Build();
        }
        protected override async void OnStartup(StartupEventArgs e)
        {
            await AppHost!.StartAsync();

            var startForm = AppHost.Services.GetRequiredService<MainWindow>();
            startForm.Show();

            base.OnStartup(e);
        }
        protected override async void OnExit(ExitEventArgs e)
        {
            await AppHost!.StopAsync();
            base.OnExit(e);
        }
    }
}
