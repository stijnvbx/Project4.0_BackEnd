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
        public string Name { get; set; }

        //Relations
        public int SensorTypeID { get; set; }
        public SensorType SensorType { get; set; }
    }
}
