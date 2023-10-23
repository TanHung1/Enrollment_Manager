using System.ComponentModel.DataAnnotations;

namespace Phanmemquanlyghidanh.Models
{
    public class SubjectCategory
    {
        [Key]
        public int SubjectCategoryId { get; set; }
        [Required(ErrorMessage = "Tên bộ môn không được để trống.")]
        public string SubjectCategory_Name { get; set; }

        public virtual ICollection<Subject> Subjects { get; set; } = new List<Subject>();



    }
}
