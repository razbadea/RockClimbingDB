using RockClimbingDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RockClimbingDb.DAL
{
    public class CragRepository
    {
        public void Add(Crag crag)
        {
            using(var db = new RockClimbingDbContext())
            {
                db.Crags.Add(crag);
                db.SaveChanges();
            }
        }

        public List<Crag> GetAllCragsByArea(int? areaId)
        {
            using (var db = new RockClimbingDbContext())
            {
                db.Configuration.LazyLoadingEnabled = false;
                db.Configuration.ProxyCreationEnabled = false;
                var result = db
                    .Crags
                    .Where(t => t.AreaId == areaId)
                    .ToList();
                return result;
            }
        }

        public List<SelectListItem> GetAllCragsByAreaAsSelectList(int areaId)
        {
            var result = new List<SelectListItem>();
            var dbCrags = GetAllCragsByArea(areaId);

            foreach (var crag in dbCrags)
            {
                result.Add(new SelectListItem()
                {
                    Text = crag.Name,
                    Value = crag.Id.ToString()
                });
            }
            return result;
        }
    }
}