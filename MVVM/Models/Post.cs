using SQLite;
using System;
using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoApplication.MVVM.Models
{
    [Table("Posts")]
    public class Post
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int AuthorId { get; set; }
        public int AssigmentId { get; set; }

        public string Url { get; set; }
        public User Photographer { get; set; }
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
