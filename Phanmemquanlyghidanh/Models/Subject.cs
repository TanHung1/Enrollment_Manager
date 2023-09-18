using System.ComponentModel.DataAnnotations;

namespace Phanmemquanlyghidanh.Models
{
    public class Subject
    {
        [Key]
        public int Subject_Id { get; set; }


        public string Subject_Name { get; set; }

        public string Level { get; set; }

        public int Age { get; set; }

        public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();

        public virtual ICollection<ClassRoom> Classrooms { get; set; } = new List<ClassRoom>();
    }
}
