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

            if (context.UserTypes.Any())
            {
                return;
            }

            context.UserTypes.AddRange(
                new UserType { UserTypeName = "admin" },
                new UserType { UserTypeName = "medewerker" },
                new UserType { UserTypeName = "user" }
                );
            context.SaveChanges();
            context.Users.AddRange(
                new User { FirstName = "admin", LastName = "adminson", Password = "test", Email = "admin@test.be", Address = "wijerken 41", PostalCode = "3920", City = "Lommel", UserTypeID = 1 },
                new User { FirstName = "medewerker", LastName = "vito", Password = "test", Email = "user1@vito.be", Address = "wijerken 41", PostalCode = "3920", City = "Lommel", UserTypeID = 2 },
                new User { FirstName = "Gust", LastName = "van der Sanden", Password = "gust", Email = "gustvdsanden@gmail.com", Address = "wijerken 41", PostalCode = "3920", City = "Lommel", UserTypeID = 3 }
                );
            context.SaveChanges();
            context.Boxes.AddRange(
                new Box { MacAddress = "123ABC", Name = "SensorBox 1b", Comment = "De box van team 1", Active = true },
                new Box { MacAddress = "123ABC", Name = "SensorBox 2b", Comment = "De box van team 2", Active = true },
                new Box { MacAddress = "123ABC", Name = "SensorBox 3b", Comment = "De box van team 3", Active = true }
                );
            context.SaveChanges();
            context.BoxUsers.AddRange(
                new BoxUser { BoxID = 1, UserID = 1, StartDate = new DateTime(), EndDate = new DateTime() },
                new BoxUser { BoxID = 2, UserID = 2, StartDate = new DateTime(), EndDate = new DateTime() },
                new BoxUser { BoxID = 3, UserID = 3, StartDate = new DateTime(), EndDate = new DateTime() }
                );
            context.SaveChanges();
            context.SensorTypes.AddRange(
                new SensorType { Name = "temperatuur", Unit = "C" },
                new SensorType { Name = "windsnelheid", Unit = "km/u" },
                new SensorType { Name = "Bodenvochtigheid", Unit = ""}
                );
            context.SaveChanges();
            context.Sensors.AddRange(
                new Sensor { Name = "Grondtemperatuur", SensorTypeID = 1 },
                new Sensor { Name = "Luchttemperatuur", SensorTypeID = 1 },
                new Sensor { Name = "Windsnelheid", SensorTypeID = 2 },
                new Sensor { Name = "Bodemvochtigheid", SensorTypeID = 3 }
                );
            context.SaveChanges();
            context.SensorBoxes.AddRange(
                new SensorBox { SensorID = 1, BoxID = 1 },
                new SensorBox { SensorID = 1, BoxID = 2 },
                new SensorBox { SensorID = 2, BoxID = 1 }
                );
            context.SaveChanges();
            context.Measurements.AddRange(
                new Measurement { BoxID = 1, SensorID = 1, Timestamp = new DateTime(), Value = "200"}
                );
            context.SaveChanges();
        }
    }
}
