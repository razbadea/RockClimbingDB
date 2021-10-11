using RockClimbingDb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace RockClimbingDb.DAL
{
    public class RockClimbContext : ApplicationDbContext
    {
        public RockClimbContext():
            base()
        { }

        public DbSet<Climber> Climbers { get; set; }
        public DbSet<Climb> Climbs { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<Sector> Sectors { get; set; }
        public DbSet<Crag> Crags { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}