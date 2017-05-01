namespace RocketLaunch.DAL
{
    using RocketLaunch.Models;
    using System;
    using System.Data.Entity;
    using System.Runtime.CompilerServices;

    public class RocketLauncherDAL : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rocket>().ToTable("Rockets");
            modelBuilder.Entity<Satellite>().ToTable("Satellites");
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Rocket> Rockets { get; set; }

        public DbSet<Satellite> Satellites { get; set; }
    }
}

