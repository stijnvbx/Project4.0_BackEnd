using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Project4._0_BackEnd.Models
{
    public class SensorBox
    {
        //Relations
        [ForeignKey("Box")]
        public int BoxID { get; set; }
        public Box Box { get; set; }
        [ForeignKey("Sensor")]
        public int SensorID { get; set; }
        public Sensor Sensor { get; set; }
        [NotMapped]
        public ICollection<Measurement> Measurements { get; set; }
    }
}
