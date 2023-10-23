using System.ComponentModel.DataAnnotations;

namespace Phanmemquanlyghidanh.Models
{
    public class SchoolYear
    {
        [Key]
        public int SchooYearId { get; set; }

        [Required(ErrorMessage = "Tên niên khóa không được để trống.")]
        public string SchoolYearName { get; set; }

        public virtual ICollection<ClassRoom> ClassRooms { get; set; } = new List<ClassRoom>();
    }
}
