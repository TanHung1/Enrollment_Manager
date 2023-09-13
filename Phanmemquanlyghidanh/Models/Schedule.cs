using System.ComponentModel.DataAnnotations;

namespace Phanmemquanlyghidanh.Models
{
    public class Schedule
    {
        [Key]
        public int Schedule_ID { get; set; }

        public string Schedule_Name { get; set; }

        public DateTime TimeStart { get; set; }

        public DateTime TimeEnd { get; set; }

        public string Contact { get; set; }

        public virtual ICollection<ClassRoom> ClassRooms { get; set; } = new List<ClassRoom>();

    }
}
