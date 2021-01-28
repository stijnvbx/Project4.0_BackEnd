using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project4._0_BackEnd.Models
{
    public class Location
    {
        public int LocationID { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        //Relations
        [ForeignKey("BoxUser")]
        public int BoxUserID { get; set; }
        public BoxUser BoxUser { get; set; }
    }
}
