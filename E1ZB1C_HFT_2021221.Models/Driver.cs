﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E1ZB1C_HFT_2021221.Models
{
    [Table("Driver")]
    public class Driver
    {
        [Key]
        public int Driver_id { get; set; }

        [NotMapped]
        public Car car { get; set; }

        [MaxLength(100)]
        public string Driver_name { get; set; }

        public int Driver_salary { get; set; }
    }
}