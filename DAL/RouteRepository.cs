using RockClimbingDb.Models;
using RockClimbingDb.ViewModels;
using System;
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

        public RouteDetailsViewModel GetRouteWithLocationDetailsByRouteId(int routeId)
        {
            using (var db = new RockClimbingDbContext())
            {
                var route = db
                    .Routes
                    .FirstOrDefault(t => t.Id == routeId);
                var sector = db.Sectors.FirstOrDefault(t => t.Id == route.SectorId);
                var crag = db.Crags.FirstOrDefault(t => t.Id == sector.CragId);
                var area = db.Areas.FirstOrDefault(t => t.Id == crag.AreaId);
                var country = db.Countries.First(t => t.Id == area.CountryId);
                var result = new RouteDetailsViewModel() 
                {
                    Name = route.Name,
                    Grade = route.Grade,
                    Rating = route.Rating,
                    SectorName = sector.Name,
                    CragName = crag.Name,
                    AreaName = area.Name,
                    CountryName = country.Name
                };

                return result;
            }
        }

        public EditRouteViewModel GetEditRouteViewModelByRouteId(int routeId)
        {
            using (var db = new RockClimbingDbContext())
            {
                var route = db
                    .Routes
                    .FirstOrDefault(t => t.Id == routeId);
                var sector = db.Sectors.FirstOrDefault(t => t.Id == route.SectorId);
                var crag = db.Crags.FirstOrDefault(t => t.Id == sector.CragId);
                var area = db.Areas.FirstOrDefault(t => t.Id == crag.AreaId);
                var country = db.Countries.First(t => t.Id == area.CountryId);
                var result = new EditRouteViewModel()
                {
                    Name = route.Name,
                    Grade = route.Grade,
                    Rating = route.Rating,
                    SectorId = route.SectorId,
                    CragId = route.Sector.CragId,
                    AreaId = route.Sector.Crag.AreaId,
                    CountryId = route.Sector.Crag.Area.CountryId,
                };

                return result;
            }
        }

        public void UpdateRoute(Route route)
        {
            using (var db = new RockClimbingDbContext())
            {
                var dbRoute = db.Routes.FirstOrDefault(t => t.Id == route.Id);
                if (dbRoute != null)
                {
                    dbRoute.Name = route.Name;
                    dbRoute.Grade = route.Grade;
                    dbRoute.Rating = route.Rating;
                    dbRoute.SectorId = route.SectorId;
                    db.SaveChanges();
                }
            }
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