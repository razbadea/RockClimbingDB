using RockClimbingDb.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace RockClimbingDb.DAL
{
    public class RouteRepository
    {
        public List<Route> GetAllRoutesBySector(int? sectorId) 
        {
            List<Route> result;
            using (var db = new RockClimbingDbContext())
            {
                db.Configuration.LazyLoadingEnabled = false;
                db.Configuration.ProxyCreationEnabled = false;
                result = db
                    .Routes
                    .Where(x => x.SectorId == sectorId)
                    .ToList();
            }
            return result;
        }

        public List<Route> GetRoutesByName(string name)
        {
            List<Route> result;
            using (var db = new RockClimbingDbContext())
            {
                result = db
                    .Routes
                    .Where(t => t.Name == name)
                    .ToList();
            }
            return result;
        }

        public List<Route> GetRoutes()
        {
            List<Route> result;

            using (var db = new RockClimbingDbContext())
            {
                result = db
                    .Routes
                    .Include(t => t.Sector)
                    .Include(t => t.Sector.Crag)
                    .Include(t => t.Sector.Crag.Area)
                    .Include(t => t.Sector.Crag.Area.Country)
                    .ToList();
            }
            return result;
        }

        public List<SelectListItem> GetRoutesBySectorAsSelectList(int sectorId)
        {
            var result = new List<SelectListItem>();
            var dbRoutes = GetAllRoutesBySector(sectorId);
            foreach (var route in dbRoutes)
            {
                result.Add(new SelectListItem
                {
                    Text = $"{route.Name} ({route.Sector.Name})",
                    Value = route.Id.ToString()
                });
            }
            return result;
        }

        public List<SelectListItem> GetRoutesAsSelectList()
        {
            var result = new List<SelectListItem>();
            var dbRoutes = GetRoutes();
            foreach (var route in dbRoutes)
            {
                result.Add(new SelectListItem
                {
                    Text = $"{route.Name} ({route.Sector.Name})",
                    Value = route.Id.ToString()
                });
            }
            return result;
        }

        public void Add(Route route)
        {
            using(var db = new RockClimbingDbContext())
            {
                db.Routes.Add(route);
                db.SaveChanges();
            }
        }
    }
}