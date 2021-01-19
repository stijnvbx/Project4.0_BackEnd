using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Project4._0_BackEnd.Models
{
    public class Box
    {
        public int BoxID { get; set; }
        public string MacAddress { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public bool Active { get; set; }
        public DateTime InstalledOn { get; set; }

        //Relations
        [ForeignKey("User")]
        public int LandbouwerID { get; set; }
        public User Landbouwer { get; set; }
        [JsonIgnore]
        public ICollection<Snapshot> Snapshots { get; set; }
    }
}
