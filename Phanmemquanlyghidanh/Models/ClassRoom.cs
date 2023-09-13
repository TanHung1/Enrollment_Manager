﻿using System.ComponentModel.DataAnnotations;

namespace Phanmemquanlyghidanh.Models
{
    public class ClassRoom
    {
        [Key]
        public int ClassRoom_ID { get; set; }

        public int ClassRoom_Name { get; set; }

        public int Schedule_ID { get; set; }
        public string ClassRoom_Description { get; set; }
        public int Subject_ID { get; set; }

        public string SchoolDay { get; set; }

        public string TimeClass { get; set; }

        public decimal Fee { get; set; }

        public int NumberofStudent { get; set; }

        public string SchoolRoom { get; set; }

        public int StatusRoom_ID { get; set; }

        public int Teacher_ID { get; set; }

        public int Student_ID { get; set; }

        public int CheckOut_ID { get; set; }
    }
}
