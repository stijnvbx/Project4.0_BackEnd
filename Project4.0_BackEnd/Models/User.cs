using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Project4._0_BackEnd.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Street { get; set; }
        public string Housenr { get; set; }
        public string Bus { get; set; }
        public string Postalcode { get; set; }
        public string City { get; set; }


        //Relations
        [ForeignKey("Usertype")]
        public int UsertypeID { get; set; }
        public Usertype Usertype { get; set; }
        [JsonIgnore]
        public ICollection<Box> Boxes { get; set; }
    }
}
