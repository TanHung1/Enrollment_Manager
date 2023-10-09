using System.ComponentModel.DataAnnotations;

namespace Phanmemquanlyghidanh.Models
{
    public class Schedule
    {
        [Key]
        public int Schedule_Id { get; set; }

        public string Schedule_Name { get; set; }

        public string Day { get; set; }

        public DateTime TimeStart { get; set; }

        public DateTime TimeEnd { get; set; }

        public string Contact { get; set; }

        public ICollection<ClassRoom> ClassRooms { get; set; }

    }
}
