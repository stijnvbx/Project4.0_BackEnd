using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project4._0_BackEnd.Models
{
    public class Measurement
    {
        public int MeasurementID { get; set; }
        public string Value { get; set; }
        public DateTime Timestamp { get; set; }

        //Relations
        [ForeignKey("Sensor")]
        public int SensorID { get; set; }
        public Sensor Sensor { get; set; }
    }
}
