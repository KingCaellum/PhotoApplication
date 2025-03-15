using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoApplication.MVVM.Models
{
    [Table("Membership")]
    public class Membership
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int UserId { get; set; }

        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; }

        public bool IsSupermember { get; set; } = false;

        public string MembershipTitle { get; set; }
        public decimal MembershipPrice { get; set; }

        public List<User> Users { get; set; } = new List<User>();
        
    }
}
