using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project4._0_BackEnd.Models;

namespace Project4._0_BackEnd.Data
{
    public class ApiContext : DbContext
    {

        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<BoxUser> BoxUsers { get; set; }

        public DbSet<SensorBox> SensorBoxes { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<Measurement> Measurements { get; set; }

        public DbSet<Sensor> Sensors { get; set; }

        public DbSet<SensorType> SensorTypes { get; set; }

        public DbSet<Box> Boxes { get; set; }

        public DbSet<Monitoring> Monitorings { get; set; }

        public DbSet<UserType> UserTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserType>().ToTable("Usertype");
            modelBuilder.Entity<SensorType>().ToTable("Sensortype");
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Sensor>().ToTable("Sensor");
            modelBuilder.Entity<Box>().ToTable("Box");
            modelBuilder.Entity<Box>().HasMany(b => b.Monitorings).WithOne(s => s.Box);
            modelBuilder.Entity<Box>().HasMany(b => b.BoxUsers).WithOne(b => b.Box);
            modelBuilder.Entity<BoxUser>().ToTable("BoxUser");
            modelBuilder.Entity<BoxUser>().HasOne(b => b.User).WithMany(b => b.BoxUsers);
            modelBuilder.Entity<BoxUser>().HasOne(b => b.Box).WithMany(b => b.BoxUsers);
            modelBuilder.Entity<BoxUser>().HasMany(b => b.Locations).WithOne(b => b.BoxUser);
            modelBuilder.Entity<Monitoring>().ToTable("Monitoring");
            modelBuilder.Entity<Monitoring>().HasOne(m => m.Box).WithMany(m => m.Monitorings);
            modelBuilder.Entity<SensorBox>().ToTable("SensorBox");
            modelBuilder.Entity<SensorBox>().HasKey(s => new { s.BoxID, s.SensorID });
            modelBuilder.Entity<SensorBox>().HasOne(s => s.Box).WithMany(s => s.SensorBoxes);
            modelBuilder.Entity<Measurement>().ToTable("Measurement");
            modelBuilder.Entity<Measurement>().HasOne(m => m.SensorBox).WithMany(m => m.Measurements).HasForeignKey(m => new { m.BoxID, m.SensorID });
            modelBuilder.Entity<Location>().ToTable("Location");
        }

    }
}
