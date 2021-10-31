﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E1ZB1C_HFT_2021221.Models
{
    [Table("Company")]
    public class Company
    {
        [Key]
        public int Company_id { get; set; }
        
        [MaxLength(100)]
        public string Company_name { get; set; }

        [NotMapped]
        public virtual ICollection<Car> Cars { get; set; }

        public Company()
        {
            Cars = new HashSet<Car>();
        }
    }
}
