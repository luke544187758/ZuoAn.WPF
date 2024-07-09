using Gao.MvvmToolkit.Demo.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace Gao.MvvmToolkit.Demo.Views
{
    /// <summary>
    /// LoginView.xaml 的交互逻辑
    /// </summary>
    public partial class LoginView
    {
        public LoginView()
        {
            InitializeComponent();
            this.DataContext = App.Current.Services.GetRequiredService<LoginViewModel>();
        }
    }
}
