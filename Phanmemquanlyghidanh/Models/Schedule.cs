using System.ComponentModel.DataAnnotations;

namespace Phanmemquanlyghidanh.Models
{
    public class Schedule
    {
        [Key]
        public int ScheduleId { get; set; }

        public int ClassRoomId { get; set; }
        public int SubjectId { get; set; }
        public DateTime TimeStart { get; set; }

        public DateTime TimeEnd { get; set; }

        public string Day { get; set; }

        public string? SchoolRoom { get; set; }

        public DateTime DayStart { get; set; }
        public DateTime DayEnd { get; set; }
        public int AccountId { get; set; }



    }
}
