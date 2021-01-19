using Project4._0_BackEnd.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project4._0_BackEnd.Models
{
    public class DbInitializer
    {
        public static void Initialize(ApiContext context)
        {
            context.Database.EnsureCreated();

            if (context.Usertypes.Any())
            {
                return;
            }

            context.Usertype.AddRange(
               new Usertype { UserTypeName = "admin" },
               new Usertype { UserTypeName = "Vmedewerker" },
               new Usertype { UserTypeName = "user" }
                );
        }
    }
}
