using RockClimbingDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RockClimbingDb.DAL
{
    public class AreaRepository
    {
        public void Add(Area area)
        {
            using(var db = new RockClimbingDbContext())
            {
                db.Areas.Add(area);
                db.SaveChanges();
            }
        }

        public List<Area> GetAllAreasByCountry(int? countryId)
        {
            using(var db = new RockClimbingDbContext())
            {
                db.Configuration.LazyLoadingEnabled = false;
                db.Configuration.ProxyCreationEnabled = false;
                var result = db
                    .Areas
                    .Where(t => t.CountryId == countryId)
                    .ToList();
                return result;
            }
        }

        public List<SelectListItem> GetAllAreasByCountryAsSelectedList(int countryId)
        {
            var result = new List<SelectListItem>();
            var dbAreas = GetAllAreasByCountry(countryId);
            foreach (var area in dbAreas)
            {
                result.Add(new SelectListItem
                {
                    Text = area.Name,
                    Value = area.Id.ToString()
                });
            }
            return result;
        }
    }
}