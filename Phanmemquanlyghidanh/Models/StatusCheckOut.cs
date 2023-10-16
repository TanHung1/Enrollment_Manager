using System.ComponentModel.DataAnnotations;

namespace Phanmemquanlyghidanh.Models
{
    public class StatusCheckOut
    {
        [Key]
        public int StatusCheckOutId { get; set; }

        public string StatusCheckOutName { get; set; }

        public ICollection<CheckOut> CheckOuts { get; set; } = new List<CheckOut>();
    }
}
