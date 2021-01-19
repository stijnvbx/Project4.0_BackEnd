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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("user");
        }

        public DbSet<Project4._0_BackEnd.Models.Measurement> Measurement { get; set; }

        public DbSet<Project4._0_BackEnd.Models.Sensor> Sensor { get; set; }

        public DbSet<Project4._0_BackEnd.Models.Sensortype> Sensortype { get; set; }

        public DbSet<Project4._0_BackEnd.Models.Box> Box { get; set; }

        public DbSet<Project4._0_BackEnd.Models.Snapshot> Snapshot { get; set; }

        public DbSet<Project4._0_BackEnd.Models.Usertype> Usertype { get; set; }

    }
}
