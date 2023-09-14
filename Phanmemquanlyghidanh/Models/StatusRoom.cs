using System.ComponentModel.DataAnnotations;

namespace Phanmemquanlyghidanh.Models
{
    public class StatusRoom
    {
        [Key]
        public int StatusRoom_Id { get; set; }

        public string StatusRoom_Name { get; set; }

        public virtual ICollection<ClassRoom> Classrooms { get; set; } = new List<ClassRoom>();
    }
}
