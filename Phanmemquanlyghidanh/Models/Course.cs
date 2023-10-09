using System.ComponentModel.DataAnnotations;

namespace Phanmemquanlyghidanh.Models
{
    public class Course
    {
        [Key]
        public int Course_Id { get; set; }
        [Required(ErrorMessage = "Mã khóa không được để trống.")]
        public string Couse_Code { get; set; }
        [Required(ErrorMessage = "Tên khóa không được để trống.")]
        public string Course_Name { get; set; }

        public ICollection<Subject> Subjects { get; set; }
    }
}