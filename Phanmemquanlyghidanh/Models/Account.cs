using System.ComponentModel.DataAnnotations;

namespace Phanmemquanlyghidanh.Models
{
    public class Account
    {
        [Key]
        public int AccountId { get; set; }
        [Required(ErrorMessage = "Tên đầu không được để trống.")]
        public string? FirstName { get; set; }
        [Required(ErrorMessage = "Tên cuối không được để trống.")]
        public string? LastName { get; set; }
        [Required(ErrorMessage = "Giới tính không được để trống.")]
        public int GenderId { get; set; }
        [Required(ErrorMessage = "Email không được để trống.")]
        public string? Email { get; set; }
        public int IdentityCard { get; set; }
        public string? PhoneNumber { get; set; }

        public string? Address { get; set; }

        public DateTime DateofBirth { get; set; }

        public string? Name_Parent { get; set; }

        public string? Avatar { get; set; }

        [Required(ErrorMessage = "Mật khẩu không được để trống.")]
        public string? Password { get; set; }
        public DateTime CooperationDay { get; set; }

        public int RoleId { get; set; }

        public int ClassRoomId { get; set; }

        public virtual ICollection<Mark> marks { get; set; } = new List<Mark>();

        public virtual ICollection<CheckOut> checkouts { get; set; } = new List<CheckOut>();

        public virtual ICollection<Schedule> schedules { get; set; } = new List<Schedule>();

    }
}
