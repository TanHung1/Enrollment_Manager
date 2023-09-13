using System.ComponentModel.DataAnnotations;

namespace Phanmemquanlyghidanh.Models
{
    public class Teacher
    {
        [Key]
        public int Teacher_ID { get; set; }
        public string Teacher_FirstName { get; set; }

        public string Teacher_LastName { get; set; }
        public int IdentityCard { get; set; }

        public string Teacher_Gender { get; set; }
        public DateTime DateofBirth { get; set; }

        public string Teacher_Address { get; set; }

        public string Teacher_Avatar { get; set; }

        public string Teacher_PhoneNumber { get; set; }

        public int Subject_ID { get; set; }

        public string Subject { get; set; }

        public string Password { get; set; }

        public virtual ICollection<ClassRoom> Classrooms { get; set; } = new List<ClassRoom>();

    }
}
