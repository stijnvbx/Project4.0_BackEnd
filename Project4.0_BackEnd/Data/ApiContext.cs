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

        public DbSet<Measurement> Measurements { get; set; }

        public DbSet<Sensor> Sensors { get; set; }

        public DbSet<Sensortype> Sensortypes { get; set; }

        public DbSet<Box> Boxes { get; set; }

        public DbSet<Snapshot> Snapshots { get; set; }

        public DbSet<Usertype> Usertypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usertype>().ToTable("Usertype");
            modelBuilder.Entity<Sensortype>().ToTable("Sensortype");
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<User>().HasOne(u => u.Usertype);
            modelBuilder.Entity<User>().HasMany(u => u.Boxes);
            modelBuilder.Entity<Measurement>().ToTable("Measurement");
        }

    }
}
