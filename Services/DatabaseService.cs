using SQLite;
using PhotoApplication.MVVM.Models;
using System.IO;
using System.Threading.Tasks;

namespace PhotoApplication.Services
{
    public class DatabaseService
    {
        private readonly SQLiteAsyncConnection _connection;

        public DatabaseService(string dbPath)
        {
            _connection = new SQLiteAsyncConnection(dbPath);
        }

        public async Task InitializeDatabaseAsync()
        {
            await _connection.CreateTableAsync<User>();
            await _connection.CreateTableAsync<Assignment>();
            await _connection.CreateTableAsync<Comment>();
            await _connection.CreateTableAsync<Membership>();
            await _connection.CreateTableAsync<Post>();
        }

        public async Task<int> AddUserAsync(User user)
        {
            return await _connection.InsertAsync(user);
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _connection.Table<User>()
                                    .Where(u => u.Email == email)
                                    .FirstOrDefaultAsync();
        }

        public async Task<int> UpdateUserAsync(User user)
        {
            return await _connection.UpdateAsync(user);
        }

        // Haal alle records op voor een bepaald model
        public async Task<List<T>> GetAllAsync<T>() where T : new()
        {
            return await _connection.Table<T>().ToListAsync();
        }

        // Haal een record op via ID
        public async Task<T> GetByIdAsync<T>(int id) where T : new()
        {
            return await _connection.FindAsync<T>(id);
        }

        // Opslaan of bijwerken van een record
        public async Task<int> SaveAsync<T>(T entity)
        {
            return await _connection.InsertOrReplaceAsync(entity);
        }

        // Insert een nieuw record
        public async Task<int> InsertAsync<T>(T entity)
        {
            return await _connection.InsertAsync(entity);
        }

        // Verwijder een record
        public async Task<int> DeleteAsync<T>(T entity)
        {
            return await _connection.DeleteAsync(entity);
        }

    }
}
