using SQLite;
using System;
using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PhotoApplication.MVVM.Models
{
    [Table("Assignment")]
    public class Assignment
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Theme { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; }

        public int CreatedUserId { get; set; }

        public List<string> SubmittedPhotos { get; set; } = new List<string>(); 
    }
}
