using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PhotoApplication.Services;
using PhotoApplication.MVVM.Models;
using PhotoApplication;
using Microsoft.Maui.Storage;
using PhotoApplication.MVVM.ViewModels;
using System.Windows.Input;
using PhotoApplication.MVVM.Views;

namespace PhotoApplication.MVVM.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly DatabaseService _databaseService;

        private string _email;
        private string _password;

        public string Email
        {
            get => _email;
            set { _email = value; OnPropertyChanged(); }
        }

        public string Password
        {
            get => _password;
            set { _password = value; OnPropertyChanged(); }
        }

        public ICommand LoginCommand { get; }
        //public ICommand RegisterCommand { get; }
        //public ICommand ForgotPasswordEmailCommand { get; }

        public LoginViewModel()
        {
            _databaseService = new DatabaseService();
            LoginCommand = new Command(async () => await Login());
            //RegisterCommand = new Command(async () => await Register());
            //ForgotPasswordEmailCommand = new Command(async () => await ForgotPasswordEmail());
        }


        private async Task Login()
        {
            var users = await _databaseService.GetAllAsync<User>();
            Console.WriteLine($"Aantal gebruikers in database: {users.Count}");

            var foundUser = users.FirstOrDefault(u => u.Email == Email);
            if (foundUser == null)
            {
                Console.WriteLine("❌ Geen gebruiker gevonden met dit e-mailadres.");
                await App.Current.MainPage.DisplayAlert("Login Mislukt", "E-mailadres bestaat niet.", "OK");
                return;
            }

            if (foundUser.Password != Password)
            {
                Console.WriteLine("❌ Onjuist wachtwoord.");
                await App.Current.MainPage.DisplayAlert("Login Mislukt", "Onjuist wachtwoord.", "OK");
                return;
            }

            Console.WriteLine($"✅ Inloggen geslaagd! Welkom {foundUser.Username}");

            await SecureStorage.SetAsync("LoggedInUserId", foundUser.Id.ToString());
            await SecureStorage.SetAsync("LoggedInUser", foundUser.Username);

            App.Current.MainPage = new MainPage();
        }



        /*
        private async Task Register()
        {
            App.Current.MainPage = new RegisterPage();
        }

        private async Task ForgotPasswordEmail()
        {
            App.Current.MainPage = new ResetPasswordEmailPage();
        }*/
    }
}
