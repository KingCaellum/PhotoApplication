using PhotoApplication.MVVM.Models;
using System.Threading.Tasks;
using System.Linq;

namespace PhotoApplication.Services
{
    public class UserService
    {
        private readonly DatabaseService _database;

        public UserService(DatabaseService databaseService)
        {
            _database = databaseService;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            var users = await _database.GetAllAsync<User>();
            return users.FirstOrDefault(u => u.Email == email);
        }

        public async Task<bool> UpgradeToSuperMember(string email)
        {
            var user = await GetUserByEmail(email);
            if (user != null && user.Role == "Member")
            {
                user.Role = "SuperMember";
                await _database.SaveAsync(user);
                return true;
            }
            return false;
        }
    }
}
