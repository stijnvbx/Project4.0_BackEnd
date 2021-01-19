using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Project4._0_BackEnd.Models
{
    public class Sensor
    {
        public int SensorID { get; set; }
        public DateTime InstalledOn { get; set; }

        //Relations
        [ForeignKey("Box")]
        public int BoxID { get; set; }
        public Box Box { get; set; }

        public int SensortypeID { get; set; }
        public Sensortype Sensortype { get; set; }

        [JsonIgnore]
        public ICollection<Measurement> Measurements { get; set; }
    }
}
