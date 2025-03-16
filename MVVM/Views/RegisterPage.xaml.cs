using PhotoApplication.MVVM.ViewModels;
using PhotoApplication.Services;
using Microsoft.Maui.Controls;

namespace PhotoApplication.MVVM.Views
{
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
            BindingContext = new RegisterViewModel(App.DatabaseService);
        }
    }
}
