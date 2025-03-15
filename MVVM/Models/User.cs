using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoApplication.MVVM.Models
{
    [Table("Users")]
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [NotNull]
        public string Email { get; set; }

        [NotNull]
        public string Username { get; set; }

        [NotNull]
        public string Password { get; set; }

        public string ProfilePicture { get; set; }
        public string Role { get; set; } = "Member";

        public int Points { get; set; } = 5;



        public void ChangeEmail(string newEmail)
        {
            if (string.IsNullOrWhiteSpace(newEmail))
                throw new ArgumentException("E-mail mag niet leeg zijn.");

            Email = newEmail;
        }

        public void ChangePassword(string newPassword)
        {
            if (string.IsNullOrWhiteSpace(newPassword))
                throw new ArgumentException("Wachtwoord mag niet leeg zijn.");

            // placeholder until i feel like encrypting passwords
            Password = newPassword;
        }

        public void ChangeProfilePicture(string newProfilePicture)
        {
            ProfilePicture = newProfilePicture;
        }

    }
}
