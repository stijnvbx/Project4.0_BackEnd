using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project4._0_BackEnd.Models
{
    public class Monitoring
    {
        public int MonitoringID { get; set; }
        public double BatteryPercentage { get; set; }
        public bool BatteryStatus { get; set; }
        public double SDCapacity { get; set; }

        //Relations
        [ForeignKey("Box")]
        public int BoxID { get; set; }
        public Box Box { get; set; }
    }
}
