using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gao.MvvmToolkit.Demo.ViewModels
{
    public partial class LoginViewModel : ObservableObject
    {
        //Fields
        [ObservableProperty]
        private string _tenant;
        [ObservableProperty]
        private string _username;
        [ObservableProperty]
        private string _password;
        [ObservableProperty]
        private string _errMessage;
        [ObservableProperty]
        private bool _isRemember;

        public LoginViewModel()
        {
            
        }

        //Methods

        // Commands
        [RelayCommand]
        private void LoginAsync()
        {

        }
    }
}
