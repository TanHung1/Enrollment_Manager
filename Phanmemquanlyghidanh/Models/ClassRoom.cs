using System.ComponentModel.DataAnnotations;

namespace Phanmemquanlyghidanh.Models
{
    public class ClassRoom
    {
        [Key]
        public int ClassRoomId { get; set; }
        [Required(ErrorMessage = "Tên lớp không được để trống.")]
        public string? ClassRoomName { get; set; }
        [Required(ErrorMessage = "Mã khóa không được để trống.")]
        public string? ClassRoomCode { get; set; }
        public string? ClassRoomDescription { get; set; }

        public int SchooYearId { get; set; }
        public string? SchoolDay { get; set; }

        public string? TimeClass { get; set; }

        public int CurrentStudent { get; set; }
        public int NumberofStudent { get; set; }

        public string? Avatar { get; set; }

        public decimal TuitionFee { get; set; }

        public int SubjectId { get; set; }
        public string StatusRoom { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
        public virtual ICollection<Account> Account { get; set; } = new List<Account>();

        public virtual ICollection<CheckOut> checkouts { get; set; } = new List<CheckOut>();

        public virtual ICollection<Mark> marks { get; set; } = new List<Mark>();
    }
}
