using PhotoApplication.MVVM.Views;
using PhotoApplication;
using Microsoft.Maui.Storage;
using System.Threading.Tasks;
using PhotoApplication.Services;

namespace PhotoApplication
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Start de database-initialisatie asynchroon zonder de UI te blokkeren.
            MainPage = new NavigationPage(new LoginPage());

            // We wachten hier niet op de database-initialisatie, maar zorgen ervoor dat deze in de achtergrond gebeurt.
            InitializeDatabaseAsync();
        }

        private async Task InitializeDatabaseAsync()
        {
            // Wacht asynchroon op de database-initialisatie.
            await DatabaseService.InitializeDatabaseAsync();

            // Als de gebruiker al is ingelogd, stel de juiste pagina in
            var userId = await SecureStorage.Default.GetAsync("userId");

            if (!string.IsNullOrEmpty(userId))
            {
                MainPage = new NavigationPage(new MainPage());
            }
            else
            {
                MainPage = new NavigationPage(new LoginPage());
            }
        }
    }
}
