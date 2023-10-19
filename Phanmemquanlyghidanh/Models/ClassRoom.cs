using System.ComponentModel.DataAnnotations;

namespace Phanmemquanlyghidanh.Models
{
    public class ClassRoom
    {
        [Key]
        public int ClassRoom_Id { get; set; }
        [Required(ErrorMessage = "Tên lớp không được để trống.")]
        public string? ClassRoom_Name { get; set; }
        [Required(ErrorMessage = "Mã khóa không được để trống.")]
        public string? ClassRoom_Code { get; set; }
        public string? ClassRoom_Description { get; set; }


        public string? SchoolDay { get; set; }

        public string? TimeClass { get; set; }



        public int NumberofStudent { get; set; }

        public string? SchoolRoom { get; set; }

        public string? Avatar { get; set; }

        public decimal TuitionFee { get; set; }

        public int SubjectId { get; set; }
        public int StatusRoomId { get; set; }

        public int ScheduleId { get; set; }

        public int AccountId { get; set; }

        public ICollection<CheckOut> checkOuts { get; set; }
    }
}
