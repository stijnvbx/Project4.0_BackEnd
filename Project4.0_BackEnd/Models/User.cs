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
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }

        [NotMapped]
        public string Token { get; set; }

        //Relations
        public int UserTypeID { get; set; }
        public UserType UserType { get; set; }
        [JsonIgnore]
        public ICollection<BoxUser> BoxUsers { get; set; }
    }
}
