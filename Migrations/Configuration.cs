namespace RockClimbingDb.Migrations
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using RockClimbingDb.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<RockClimbingDb.DAL.RockClimbingDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RockClimbingDb.DAL.RockClimbingDbContext context)
        {

            var adminUserRole = new IdentityRole() { Name = "Admin" };
            var userRole = new IdentityRole() { Name = "User" };
            var guestUserRole = new IdentityRole() { Name = "Guest" };
            context.Roles.Add(adminUserRole);
            context.Roles.Add(userRole);
            context.Roles.Add(guestUserRole);
            context.SaveChanges();


            var country01 = new Country() { Name = "Romania" };
            var country02 = new Country() { Name = "Greece" };
            context.Countries.Add(country01);
            context.Countries.Add(country02);
            context.SaveChanges();

            var area01 = new Area() { Name = "Brasov", CountryId = country01.Id };
            var area02 = new Area() { Name = "Herculane", CountryId = country01.Id };
            var area03 = new Area() { Name = "Kyparissi", CountryId = country02.Id };
            var area04 = new Area() { Name = "Varasova", CountryId = country02.Id };
            context.Areas.Add(area01);
            context.Areas.Add(area02);
            context.Areas.Add(area03);
            context.Areas.Add(area04);
            context.SaveChanges();

            var crag01 = new Crag() { Name = "Tampa", AreaId = area01.Id };
            var crag02 = new Crag() { Name = "Solomon", AreaId = area01.Id };
            var crag03 = new Crag() { Name = "Km9", AreaId = area02.Id };
            var crag04 = new Crag() { Name = "Vanturatoarea", AreaId = area02.Id };
            var crag05 = new Crag() { Name = "Kastraki", AreaId = area03.Id };
            var crag06 = new Crag() { Name = "Watermill", AreaId = area03.Id };
            var crag07 = new Crag() { Name = "Grarden of Heroes", AreaId = area04.Id };
            var crag08 = new Crag() { Name = "Africana", AreaId = area04.Id };
            context.Crags.Add(crag01);
            context.Crags.Add(crag02);
            context.Crags.Add(crag03);
            context.Crags.Add(crag04);
            context.Crags.Add(crag05);
            context.Crags.Add(crag06);
            context.Crags.Add(crag07);
            context.Crags.Add(crag08);
            context.SaveChanges();

            var sector01 = new Sector() { Name = "Faleza Mare", CragId = crag01.Id };
            var sector02 = new Sector() { Name = "Faleza Mica", CragId = crag01.Id };
            var sector03 = new Sector() { Name = "Grota", CragId = crag02.Id };
            var sector04 = new Sector() { Name = "La Juni", CragId = crag02.Id };
            var sector05 = new Sector() { Name = "Stanga", CragId = crag03.Id };
            var sector06 = new Sector() { Name = "Dreapta", CragId = crag03.Id };
            var sector07 = new Sector() { Name = "La cascada", CragId = crag04.Id };
            var sector08 = new Sector() { Name = "Peretele mic", CragId = crag04.Id };
            var sector09 = new Sector() { Name = "East", CragId = crag05.Id };
            var sector10 = new Sector() { Name = "North", CragId = crag05.Id };
            var sector11 = new Sector() { Name = "Sunshine", CragId = crag06.Id };
            var sector12 = new Sector() { Name = "Forest", CragId = crag06.Id };
            var sector13 = new Sector() { Name = "Left", CragId = crag07.Id };
            var sector14 = new Sector() { Name = "Right", CragId = crag07.Id };
            var sector15 = new Sector() { Name = "Multi-Pitch", CragId = crag08.Id };
            var sector16 = new Sector() { Name = "Sport", CragId = crag08.Id };
            context.Sectors.Add(sector01);
            context.Sectors.Add(sector02);
            context.Sectors.Add(sector03);
            context.Sectors.Add(sector04);
            context.Sectors.Add(sector05);
            context.Sectors.Add(sector06);
            context.Sectors.Add(sector07);
            context.Sectors.Add(sector08);
            context.Sectors.Add(sector09);
            context.Sectors.Add(sector10);
            context.Sectors.Add(sector11);
            context.Sectors.Add(sector12);
            context.Sectors.Add(sector13);
            context.Sectors.Add(sector14);
            context.Sectors.Add(sector15);
            context.Sectors.Add(sector16);
            context.SaveChanges();
        }
    }
}
