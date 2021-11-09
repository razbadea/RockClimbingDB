using Microsoft.AspNet.Identity.EntityFramework;
using RockClimbingDb.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace RockClimbingDb.DAL
{
    public class RockClimbingDbContext : IdentityDbContext<ApplicationUser>
    {
        public RockClimbingDbContext()
            : base("RockClimbingConnection", throwIfV1Schema: false)
        {
        }

        public static RockClimbingDbContext Create()
        {
            return new RockClimbingDbContext();
        }
         
        public DbSet<Climber> Climbers { get; set; }
        public DbSet<Climb> Climbs { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<Sector> Sectors { get; set; }
        public DbSet<Crag> Crags { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<RockClimbingDbContext>(null);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}