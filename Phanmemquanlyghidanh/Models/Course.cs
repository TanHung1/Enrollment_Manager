using System.ComponentModel.DataAnnotations;

namespace Phanmemquanlyghidanh.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }

        [Required(ErrorMessage = "Mã khóa không được để trống.")]
        public string CouseCode { get; set; }

        [Required(ErrorMessage = "Tên khóa không được để trống.")]
        public string CourseName { get; set; }

        public ICollection<Subject> Subjects { get; set; }
    }
}


