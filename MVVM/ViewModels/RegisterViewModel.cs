using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PhotoApplication.MVVM.Models;
using PhotoApplication.Services;
using System;
using System.Threading.Tasks;

namespace PhotoApplication.MVVM.ViewModels
{
    public class RegisterViewModel : ObservableObject
    {
        private readonly DatabaseService _dbService;

        public RegisterViewModel(DatabaseService dbService)
        {
            _dbService = dbService;
            RegisterCommand = new AsyncRelayCommand(RegisterAsync);
            NavigateToLoginCommand = new RelayCommand(() =>
            {
                // Navigate back to LoginPage (pop current page off the stack)
                Application.Current.MainPage.Navigation.PopAsync();
            });
        }

        private string email;
        public string Email
        {
            get => email;
            set => SetProperty(ref email, value);
        }

        private string username;
        public string Username
        {
            get => username;
            set => SetProperty(ref username, value);
        }

        private string password;
        public string Password
        {
            get => password;
            set => SetProperty(ref password, value);
        }

        public IAsyncRelayCommand RegisterCommand { get; }
        public IRelayCommand NavigateToLoginCommand { get; }

        private async Task RegisterAsync()
        {
            try
            {
                var existingUser = await _dbService.GetUserByEmailAsync(Email);
                if (existingUser != null)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "User already exists", "OK");
                    return;
                }

                var newUser = new User
                {
                    Email = Email,
                    Username = Username,
                    Password = Password // In production, securely hash the password
                };

                await _dbService.AddUserAsync(newUser);
                await Application.Current.MainPage.DisplayAlert("Success", "Registration successful", "OK");
                // Navigate back to LoginPage
                await Application.Current.MainPage.Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }
}
