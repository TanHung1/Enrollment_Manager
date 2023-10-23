using System.ComponentModel.DataAnnotations;

namespace Phanmemquanlyghidanh.Models
{
    public class Subject
    {
        [Key]
        public int SubjectId { get; set; }

        public int SubjectCategoryId { get; set; }
        public int CourseId { get; set; }

        [Required(ErrorMessage = "Tên môn học không được để trống.")]
        public string Subject_Name { get; set; }

        public virtual ICollection<ClassRoom> Classrooms { get; set; }

        public virtual ICollection<Mark> marks { get; set; }

        public virtual ICollection<Schedule> schedules { get; set; } = new List<Schedule>();



    }
}
