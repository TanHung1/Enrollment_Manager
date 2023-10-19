using System.ComponentModel.DataAnnotations;

namespace Phanmemquanlyghidanh.Models
{
    public class StatusRoom
    {
        [Key]
        public int StatusRoomId { get; set; }

        public string StatusRoom_Name { get; set; }

        public ICollection<ClassRoom> Classrooms { get; set; }
    }
}
