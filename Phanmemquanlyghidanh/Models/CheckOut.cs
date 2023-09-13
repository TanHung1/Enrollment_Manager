using System.ComponentModel.DataAnnotations;

namespace Phanmemquanlyghidanh.Models
{
    public class CheckOut
    {
        [Key]
        public int CheckOut_ID { get; set; }

        public string CheckOut_Name { get; set; }

        public string FeeType { get; set; }

        public string Note { get; set; }



        public virtual ICollection<Student> Students { get; set; } = new List<Student>();

        public virtual ICollection<ClassRoom> ClassRooms { get; set; } = new List<ClassRoom>();
    }
}
