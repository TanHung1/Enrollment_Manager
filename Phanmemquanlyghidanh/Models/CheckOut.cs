using System.ComponentModel.DataAnnotations;

namespace Phanmemquanlyghidanh.Models
{
    public class CheckOut
    {
        [Key]
        public int CheckOut_Id { get; set; }

        public string CheckOut_Name { get; set; }

        public string FeeType { get; set; }

        public string Note { get; set; }

        public string Price { get; set; }



        public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();

        public virtual ICollection<ClassRoom> ClassRooms { get; set; } = new List<ClassRoom>();
    }
}
