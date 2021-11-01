using RockClimbingDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RockClimbingDb.DAL
{
    public class SectorRepository
    {
        public void Add(Sector sector)
        {
            using (var db = new RockClimbingDbContext())
            {
                db
                    .Sectors
                    .Add(sector);
                db.SaveChanges();
            }
        }

        public List<Sector> GetAllSectorsByCrag(int? cragId)
        {
            using (var db = new RockClimbingDbContext())
            {
                db.Configuration.LazyLoadingEnabled = false;
                db.Configuration.ProxyCreationEnabled = false;
                var result = db
                    .Sectors
                    .Where(t => t.CragId == cragId)
                    .ToList();
                return result;
            }
        }

        public List<SelectListItem> GetAllSectorsByCragAsSelectList(int cragId)
        {
            var result = new List<SelectListItem>();
            var dbSectors = GetAllSectorsByCrag(cragId);

            foreach (var sector in dbSectors)
            {
                result.Add(new SelectListItem()
                {
                    Text = sector.Name,
                    Value = sector.Id.ToString()
                });
            }
            return result;
        }
    }
}