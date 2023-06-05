using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;

namespace StudyWPFProject
{
    
    public partial class App : Application
    {
        public static IHost? AppHost { get; private set; }
        public App()
        {
            AppHost = Host.CreateDefaultBuilder().ConfigureServices((host, services) =>
            {
                services.AddSingleton<MainWindow>();
            }).Build();
        }
        protected  override async void OnStartup(StartupEventArgs e)
        {
            await AppHost!.StartAsync();
            var startApp = AppHost!.Services.GetRequiredService<MainWindow>();
            startApp.Show();
            base.OnStartup(e);
        }
        protected  override async void OnExit(ExitEventArgs e)
        {
            await AppHost!.StopAsync();
            base.OnExit(e); 
        }
    }
}
