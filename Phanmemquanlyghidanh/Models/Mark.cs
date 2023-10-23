using System.ComponentModel.DataAnnotations;

namespace Phanmemquanlyghidanh.Models
{
    public class Mark
    {
        [Key]

        public int MarkId { get; set; }

        public decimal? FirstColumnPoint { get; set; }

        public decimal? SecondColumnPoint { get; set; }

        public decimal? ThirdColumnPoint { get; set; }

        public decimal? FourthColumnPoint { get; set; }

        public decimal? FinalExamPoint1 { get; set; }
        public decimal? FinalExamPoint2 { get; set; }
        public decimal AverageColumnPoint { get; set; }
        public int TypeID { get; set; }

        public int ClassRoomId { get; set; }

        public int SubjectId { get; set; }

        public int AccountId { get; set; }


    }
}
