using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project4._0_BackEnd.Models
{
    public class Snapshot
    {
        public int SnapshotID { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public float BatteryPercentage { get; set; }
        public bool BatteryStatus { get; set; }
        public float SDCapacity { get; set; }
        public DateTime DateTime { get; set; }

        //Relations
        [ForeignKey("Box")]
        public int BoxID { get; set; }
        public Box Box { get; set; }
    }
}
