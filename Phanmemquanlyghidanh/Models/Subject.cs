using System.ComponentModel.DataAnnotations;

namespace Phanmemquanlyghidanh.Models
{
    public class Subject
    {
        [Key]
        public int Subject_ID { get; set; }

        public int SubjectCategory_ID { get; set; }
        public string Subject_Name { get; set; }

        public string Level { get; set; }

        public int Age { get; set; }

        public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();

        public virtual ICollection<ClassRoom> Classrooms { get; set; } = new List<ClassRoom>();
    }
}
