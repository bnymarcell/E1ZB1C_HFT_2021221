using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace E1ZB1C_HFT_2021221.Models
{
    [Table("Car")]
    public class Car
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Car_id { get; set; }

        [MaxLength(200)]
        public string Car_Brand { get; set; }

        [MaxLength(200)]
        public string Car_Type { get; set; }

        [ForeignKey(nameof(Company))]
        public int Company_id { get; set; }

        [NotMapped]
        public virtual Driver Driver { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual Company Company { get; set; }
        
    }
}
