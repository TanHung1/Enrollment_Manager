using System.ComponentModel.DataAnnotations;

namespace Phanmemquanlyghidanh.Models
{
    public class HolidaySchedule
    {
        [Key]
        public int HolidayId { get; set; }

        public string NameHoliday { get; set; }

        public DateTime StartDay { get; set; }

        public DateTime EndDate { get; set; }
    }
}
