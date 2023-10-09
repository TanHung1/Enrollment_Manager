using System.ComponentModel.DataAnnotations;

namespace Phanmemquanlyghidanh.Models
{
    public class HolidaySchedule
    {
        [Key]
        public int HolidayId { get; set; }

        [Required(ErrorMessage = "Tên ngày nghỉ không được để trống.")]

        public string? NameHoliday { get; set; }
        public string? Reason { get; set; }
        [Required(ErrorMessage = "Thời gian bắt đầu không được để trống.")]
        public DateTime StartDay { get; set; }
        [Required(ErrorMessage = "Thời gian kết thúc không được để trống.")]
        public DateTime EndDate { get; set; }
    }
}
