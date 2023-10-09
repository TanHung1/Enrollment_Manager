using System.ComponentModel.DataAnnotations;

namespace Phanmemquanlyghidanh.Models
{
    public class ClassRoom
    {
        [Key]
        public int ClassRoom_Id { get; set; }
        [Required(ErrorMessage = "Mã khóa không được để trống.")]
        public string? ClassRoom_Name { get; set; }
        [Required(ErrorMessage = "Mã khóa không được để trống.")]
        public string? ClassRoom_Code { get; set; }
        public string? ClassRoom_Description { get; set; }


        public string? SchoolDay { get; set; }

        public string? TimeClass { get; set; }
        [Required(ErrorMessage = "Mã khóa không được để trống.")]
        public decimal Fee { get; set; }
        [Required(ErrorMessage = "Mã khóa không được để trống.")]
        public int NumberofStudent { get; set; }

        public string? SchoolRoom { get; set; }

        public string? Avatar { get; set; }

        public int StatusRoom_Id { get; set; }

        public int Schedule_Id { get; set; }

        public string Id { get; set; }
    }
}
