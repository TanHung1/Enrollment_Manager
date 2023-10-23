using System.ComponentModel.DataAnnotations;

namespace Phanmemquanlyghidanh.Models
{
    public class Gender
    {
        [Key]
        public int GenderId { get; set; }

        public string GenderName { get; set; }

        public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();
    }
}
