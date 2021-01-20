using Project4._0_BackEnd.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project4._0_BackEnd.Models
{
    public class DBInitializer
    {
        public static void Initialize(ApiContext context)
        {
            context.Database.EnsureCreated();

            if (context.Usertypes.Any())
            {
                return;
            }

            //Usertypes
            context.Usertypes.AddRange(
               new Usertype { UserTypeName = "admin" },
               new Usertype { UserTypeName = "Vmedewerker" },
               new Usertype { UserTypeName = "user" }
                );
            context.SaveChanges();

            //Users
            context.Users.AddRange(
               new User { FirstName = "admin", LastName = "adminson", Password = "test", Email = "admin@test.be", Street = "test", Housenr = "1", Bus = "G", Postalcode = "3920", City = "Lommel", UsertypeID = 1 },
               new User { FirstName = "medewerker", LastName = "vito", Password = "test", Email = "user1@vito.be", Street = "test", Housenr = "1", Bus = "NB", Postalcode = "3029", City = "Lommel", UsertypeID = 2 },
               new User { FirstName = "Gust", LastName = "van der Sanden", Password = "test", Email = "gustvdsanden@gmail.com", Street = "wijerken", Housenr = "41", Postalcode = "3920", City = "Lommel", UsertypeID = 3 },
               new User { FirstName = "Djorven", LastName = "Wielockx", Password = "test", Email = "djorven@gmail.com", Street = "test", Housenr = "1", Postalcode = "3920", City = "Lommel", UsertypeID = 3 },
               new User { FirstName = "Youri", LastName = "Van Laer", Password = "test", Email = "youri@gmail.com", Street = "test", Housenr = "1", Postalcode = "3920", City = "Lommel", UsertypeID = 3 },
               new User { FirstName = "Ruben", LastName = "Lievens", Password = "test", Email = "ruben@gmail.com", Street = "test", Housenr = "1", Postalcode = "3920", City = "Lommel", UsertypeID = 3 }
                ) ;
            context.SaveChanges();

            //Box
            context.Boxes.AddRange(
                new Box { MacAddress = "123ABC", Name = "Sensorbox1b", Comment = "Sensorbox van team 1B", Active = true, LandbouwerID = 3, InstalledOn = DateTime.Now },
                new Box { MacAddress = "123ABCD", Name = "Sensorbox2b", Comment = "Sensorbox van team 2B", Active = true, LandbouwerID = 4, InstalledOn = DateTime.Now },
                new Box { MacAddress = "123ABCDE", Name = "Sensorbox3b", Comment = "Sensorbox van team 3B", Active = true, LandbouwerID = 5, InstalledOn = DateTime.Now },
                new Box { MacAddress = "123ABCDEF", Name = "Sensorbox4b", Comment = "Sensorbox van team 4B", Active = true, LandbouwerID = 6, InstalledOn = DateTime.Now }
                );
            context.SaveChanges();

            //Snapshot
            context.Snapshots.AddRange(
                new Snapshot { Latitude = 30.52694556f, Longitude = 25.6541515f, BatteryPercentage = 69, BatteryStatus = true, SDCapacity = 45, DateTime = DateTime.Now, BoxID = 1 },
                new Snapshot { Latitude = 30.52694556f, Longitude = 25.6541515f, BatteryPercentage = 67, BatteryStatus = false, SDCapacity = 45, DateTime = DateTime.Now, BoxID = 1 },
                new Snapshot { Latitude = 30.52694556f, Longitude = 25.6541515f, BatteryPercentage = 64, BatteryStatus = true, SDCapacity = 45, DateTime = DateTime.Now, BoxID = 1 },
                new Snapshot { Latitude = 30.52694556f, Longitude = 25.6541515f, BatteryPercentage = 60, BatteryStatus = true, SDCapacity = 45, DateTime = DateTime.Now, BoxID = 1 },
                new Snapshot { Latitude = 30.52694556f, Longitude = 25.6541515f, BatteryPercentage = 69, BatteryStatus = false, SDCapacity = 45, DateTime = DateTime.Now, BoxID = 2 }
                );
            context.SaveChanges();

            //Sensortype
            context.Sensortypes.AddRange(
                new Sensortype { Name = "Temperatuursensor", Unit = "C" },
                new Sensortype { Name = "Luchtvochtigheid", Unit = "water/m3" },
                new Sensortype { Name = "Luchtkwaliteit", Unit = "???" },
                new Sensortype { Name = "Test", Unit = "Test" }
                );
            context.SaveChanges();

            //Sensor
            context.Sensors.AddRange(
                new Sensor { BoxID = 1, SensortypeID = 1, InstalledOn = DateTime.Now },
                new Sensor { BoxID = 2, SensortypeID = 1, InstalledOn = DateTime.Now },
                new Sensor { BoxID = 3, SensortypeID = 1, InstalledOn = DateTime.Now },
                new Sensor { BoxID = 4, SensortypeID = 1, InstalledOn = DateTime.Now },
                new Sensor { BoxID = 1, SensortypeID = 3, InstalledOn = DateTime.Now }
                );
            context.SaveChanges();

            //Measurement
            context.Measurements.AddRange(
                new Measurement { SensorID = 1, Value = "32", Timestamp = DateTime.Now },
                new Measurement { SensorID = 1, Value = "33", Timestamp = DateTime.Now },
                new Measurement { SensorID = 2, Value = "21", Timestamp = DateTime.Now },
                new Measurement { SensorID = 2, Value = "12", Timestamp = DateTime.Now }
                );
            context.SaveChanges();
        }
    }
}
