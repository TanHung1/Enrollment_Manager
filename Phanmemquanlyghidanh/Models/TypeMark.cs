﻿using System.ComponentModel.DataAnnotations;

namespace Phanmemquanlyghidanh.Models
{
    public class TypeMark
    {
        [Key]

        public int TypeID { get; set; }

        public string TypeName { get; set; }


    }
}
