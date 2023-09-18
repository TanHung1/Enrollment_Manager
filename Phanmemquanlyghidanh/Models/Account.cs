using System.ComponentModel.DataAnnotations;

namespace Phanmemquanlyghidanh.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Gender { get; set; }
        public string Email { get; set; }
        public int IdentityCard { get; set; }
        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public DateTime DateofBirth { get; set; }

        public string Name_Parent { get; set; }

        public string Avatar { get; set; }
        public string Password { get; set; }
        public DateTime CooperationDay { get; set; }


        public string Subject { get; set; }



        public virtual ICollection<ClassRoom> ClassRooms { get; set; } = new List<ClassRoom>();

    }
}
