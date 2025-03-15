using SQLite;
using System;
using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoApplication.MVVM.Models
{
    [Table("Comment")]
    public class Comment
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public User Author { get; set; }
        public string Text { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.Now;

    }
}
