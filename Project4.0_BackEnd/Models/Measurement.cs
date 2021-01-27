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
        public DateTime TimeStamp { get; set; }

        //Relations
        [ForeignKey("SensorID")]
        public int SensorID { get; set; }
        [ForeignKey("BoxID")]
        public int BoxID { get; set; }
        public SensorBox SensorBox { get; set; }
    }
}
