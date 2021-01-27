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

        public string ConfiguratieString { get; set; }
        public bool Active { get; set; }

        //Relations
        [JsonIgnore]
        public ICollection<Monitoring> Monitorings { get; set; }
        [JsonIgnore]
        public ICollection<BoxUser> BoxUsers { get; set; }
        public ICollection<SensorBox> SensorBoxes { get; set; }
    }
}
