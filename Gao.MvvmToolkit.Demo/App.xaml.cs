using Gao.MvvmToolkit.Demo.ViewModels;
using Gao.MvvmToolkit.Demo.Views;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
namespace Gao.MvvmToolkit.Demo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public new static App Current => (App)Application.Current;

        public App()
        {
            Services = ConfigureServices();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var loginView =Services.GetRequiredService<LoginView>();
            loginView.ShowDialog();
        }
        public IServiceProvider Services { get; }

        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            //注册服务

            //注册视图模型
            services.AddSingleton<LoginView>()
                .AddSingleton<LoginViewModel>();
            services.AddSingleton<MainView>()
                .AddSingleton<MainViewModel>();
            return services.BuildServiceProvider();
        }
    }

}
