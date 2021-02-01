using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Project4._0_BackEnd.Models
{
    public class BoxUser
    {
        public int BoxUserID { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        //Relations
        [ForeignKey("Box")]
        public int BoxID { get; set; }
        public Box Box { get; set; }

        [ForeignKey("User")]
        public int UserID { get; set; }
        public User User { get; set; }

        [JsonIgnore]
        public ICollection<Location> Locations { get; set; }
    }
}
