using System.ComponentModel.DataAnnotations;

namespace Phanmemquanlyghidanh.Models
{
    public class ClassRoom
    {
        [Key]
        public int ClassRoom_Id { get; set; }

        public int ClassRoom_Name { get; set; }


        public string ClassRoom_Description { get; set; }


        public string SchoolDay { get; set; }

        public string TimeClass { get; set; }

        public decimal Fee { get; set; }

        public int NumberofStudent { get; set; }

        public string SchoolRoom { get; set; }

        public string Avatar { get; set; }


    }
}
