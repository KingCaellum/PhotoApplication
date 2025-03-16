using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PhotoApplication.MVVM.Models;
using PhotoApplication.Services;
using PhotoApplication.MVVM.Views;
using System;
using System.Threading.Tasks;

namespace PhotoApplication.MVVM.ViewModels
{
    public class LoginViewModel : ObservableObject
    {
        private readonly DatabaseService _dbService;

        public LoginViewModel(DatabaseService dbService)
        {
            _dbService = dbService;
            LoginCommand = new AsyncRelayCommand(LoginAsync);
            NavigateToRegisterCommand = new RelayCommand(() =>
            {
                // Navigate to the RegisterPage using NavigationPage
                Application.Current.MainPage.Navigation.PushAsync(new RegisterPage());
            });
        }

        private string email;
        public string Email
        {
            get => email;
            set => SetProperty(ref email, value);
        }

        private string password;
        public string Password
        {
            get => password;
            set => SetProperty(ref password, value);
        }

        public IAsyncRelayCommand LoginCommand { get; }
        public IRelayCommand NavigateToRegisterCommand { get; }

        private async Task LoginAsync()
        {
            try
            {
                var user = await _dbService.GetUserByEmailAsync(Email);
                if (user == null)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "User not found", "OK");
                    return;
                }
                if (user.Password != Password)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Invalid credentials", "OK");
                    return;
                }
                // Login successful
                await Application.Current.MainPage.DisplayAlert("Success", "Login successful", "OK");
                // Navigate to MainPage (replace with your actual main page)
                await Application.Current.MainPage.Navigation.PushAsync(new MainPage());
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }
}
