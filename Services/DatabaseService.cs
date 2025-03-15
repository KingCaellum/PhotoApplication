using PhotoApplication.MVVM.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace PhotoApplication.Services
{
    public class DatabaseService
    {
        private static SQLiteAsyncConnection _database;

        public DatabaseService()
        {
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "PhotoApp.db");
            _database = new SQLiteAsyncConnection(dbPath);
        }

        public static async Task InitializeDatabaseAsync()
        {
            if (_database == null)
            {
                var dbPath = Path.Combine(FileSystem.AppDataDirectory, "PhotoApp.db");
                _database = new SQLiteAsyncConnection(dbPath);
            }

            // Maak tabellen aan voor elk model
            await _database.CreateTableAsync<User>();
            await _database.CreateTableAsync<Comment>();
            await _database.CreateTableAsync<Post>();
            await _database.CreateTableAsync<Assignment>();
            await _database.CreateTableAsync<Membership>();

            // Voeg de standaard gebruikersrollen toe
            await AddUserRolesAsync();
        }

        private static async Task AddUserRolesAsync()
        {
            var existingUsers = await _database.Table<User>().ToListAsync();

            if (existingUsers.Count == 0) // Controleer of er al gebruikers zijn
            {
                var roles = new List<User>
                {
                    new User { Email = "member@example.com", Username = "MemberUser", Password = "password", ProfilePicture = "defaultpfp.png", Role = "Member" },
                    new User { Email = "supermember@example.com", Username = "SuperMemberUser", Password = "password", ProfilePicture = "defaultpfp.png", Role = "SuperMember" },
                    new User { Email = "admin@example.com", Username = "AdminUser", Password = "password", ProfilePicture = "defaultpfp.png", Role = "Admin" }
                };

                await SaveAsync(roles);
            }
        }

        public static async Task<List<T>> GetAllAsync<T>() where T : new()
        {
            return await _database.Table<T>().ToListAsync();
        }

        public static async Task<T> GetByIdAsync<T>(int id) where T : new()
        {
            return await _database.FindAsync<T>(id);
        }

        public static async Task<int> SaveAsync<T>(T entity)
        {
            return await _database.InsertOrReplaceAsync(entity);
        }

        public static async Task<int> InsertAsync<T>(T entity)
        {
            return await _database.InsertAsync(entity);
        }

        public static async Task<int> DeleteAsync<T>(T entity)
        {
            return await _database.DeleteAsync(entity);
        }
    }
}
