using PhotoApplication.MVVM.ViewModels;
using PhotoApplication.Services;
using Microsoft.Maui.Controls;

namespace PhotoApplication.MVVM.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            // Get the shared DatabaseService instance from App
            BindingContext = new LoginViewModel(App.DatabaseService);
        }
    }
}
