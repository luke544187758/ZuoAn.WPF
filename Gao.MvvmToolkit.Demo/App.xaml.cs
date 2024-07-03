using Gao.MvvmToolkit.Demo.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
namespace Gao.MvvmToolkit.Demo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public new static App Current=>(App)Application.Current;

        public App()
        {
            Services = ConfigureServices();
        }

        public IServiceProvider Services { get; }

        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            //注册服务

            //注册视图模型
            services.AddScoped<MainViewModel>();
            return services.BuildServiceProvider();
        }
    }

}
