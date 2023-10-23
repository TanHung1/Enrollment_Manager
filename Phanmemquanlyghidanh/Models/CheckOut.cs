using System.ComponentModel.DataAnnotations;

namespace Phanmemquanlyghidanh.Models
{
    public class CheckOut
    {
        [Key]
        public int CheckOutId { get; set; }

        public string CheckOut_Name { get; set; }

        public int ClassRoomId { get; set; }

        public int AccountId { get; set; }

        public string Note { get; set; }

        public decimal Discount { get; set; }
        public decimal PricePaid { get; set; }
        public decimal Price { get; set; }

        public decimal RemainingPrice { get; set; }

        public string StatusCheckOut { get; set; }


    }
}
