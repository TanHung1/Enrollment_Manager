using System.ComponentModel.DataAnnotations;

namespace Phanmemquanlyghidanh.Models
{
    public class Student
    {
        [Key]
        public int Student_ID { get; set; }
        public string Student_FirstName { get; set; }
        public string Student_LastName { get; set; }

        public string Student_Gender { get; set; }
        public string Student_Email { get; set; }
        public string Student_PhoneNumber { get; set; }

        public string Student_Address { get; set; }

        public DateTime DateofBirth { get; set; }

        public string Name_Parent { get; set; }

        public string Student_Avatar { get; set; }
        public string Password { get; set; }

        public int CheckOut_ID { get; set; }
        public virtual ICollection<ClassRoom> ClassRooms { get; set; } = new List<ClassRoom>();

    }
}
