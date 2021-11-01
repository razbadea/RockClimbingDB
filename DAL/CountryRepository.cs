using RockClimbingDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RockClimbingDb.DAL
{
    public class CountryRepository
    {
        public void Add(Country country)
        {
            using(var db = new RockClimbingDbContext())
            {
                db.Countries.Add(country);
                db.SaveChanges();
            }
        }

        public List<Country> GetAllCountries()
        {
            using(var db = new RockClimbingDbContext())
            {
                var result = db.Countries.ToList();
                return result;
            }
        }

        public List<SelectListItem> GetCountriesAsSelectList()
        {
            var result = new List<SelectListItem>();
            var dbCountries = GetAllCountries();
            foreach (var country in dbCountries)
            {
                result.Add(new SelectListItem
                {
                    Text = country.Name,
                    Value = country.Id.ToString()
                });
            }
            return result;

        }
    }
}