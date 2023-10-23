using System.ComponentModel.DataAnnotations;

namespace Phanmemquanlyghidanh.Models
{
    public class TypeMark
    {
        [Key]

        public int TypeID { get; set; }
        [Required(ErrorMessage = "Tên loại điểm không được để trống.")]
        public string TypeName { get; set; }
        [Required(ErrorMessage = "Hệ số không được để trống.")]
        public string Coefficient { get; set; }

        public virtual ICollection<Mark> Marks { get; set; } = new List<Mark>();

    }
}
