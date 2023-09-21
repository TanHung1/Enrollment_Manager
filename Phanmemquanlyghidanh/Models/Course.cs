using System.ComponentModel.DataAnnotations;

namespace Phanmemquanlyghidanh.Models
{
    public class Course
    {
        [Key]
        public int Course_Id { get; set; }

        public string Course_Name { get; set; }

        public virtual ICollection<Subject> Subjects { get; set; } = new List<Subject>();
    }
}
