using PhotoApplication.Services;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using System.IO;
using PhotoApplication.MVVM.Views;

namespace PhotoApplication
{
    public partial class App : Application
    {
        public static DatabaseService DatabaseService { get; private set; }

        public App()
        {
            InitializeComponent();

            // Set up the database service with a path in the app's data directory
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "PhotoApp.db3");
            DatabaseService = new DatabaseService(dbPath);
            // Initialize the database (consider handling this asynchronously in production)
            DatabaseService.InitializeDatabaseAsync();

            // Wrap the LoginPage in a NavigationPage
            MainPage = new NavigationPage(new LoginPage());
        }
    }
}
