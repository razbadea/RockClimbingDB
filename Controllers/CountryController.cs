using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RockClimbingDb.DAL;
using RockClimbingDb.Models;

namespace RockClimbingDb.Controllers
{
    public class CountryController : Controller
    {
        private RockClimbingDbContext db = new RockClimbingDbContext();

        [Authorize(Roles = "Admin")]
        // GET: Country/Create
        public ActionResult Create()
        {
            return View();
        }


    }
}
