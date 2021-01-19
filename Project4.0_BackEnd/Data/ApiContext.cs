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
            modelBuilder.Entity<User>().HasMany(u => u.Boxes).WithOne(b => b.Landbouwer);
            modelBuilder.Entity<Box>().ToTable("Box");
            modelBuilder.Entity<Box>().HasOne(b => b.Landbouwer).WithMany(u => u.Boxes);
            modelBuilder.Entity<Box>().HasMany(b => b.Snapshots).WithOne(s => s.Box);
            modelBuilder.Entity<Sensor>().ToTable("Sensor");
            modelBuilder.Entity<Sensor>().HasMany(s => s.Measurements).WithOne(m => m.Sensor);
            modelBuilder.Entity<Measurement>().ToTable("Measurement");
            modelBuilder.Entity<Measurement>().HasOne(m => m.Sensor).WithMany(s => s.Measurements);
            modelBuilder.Entity<Snapshot>().ToTable("Snapshot");
            modelBuilder.Entity<Snapshot>().HasOne(s => s.Box).WithMany(b => b.Snapshots);
        }

    }
}
