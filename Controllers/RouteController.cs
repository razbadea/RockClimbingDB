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
    public class RouteController : Controller
    {
        private readonly RouteRepository _routeRepository;
        private readonly SectorRepository _sectorRepository;
        private readonly CragRepository _cragRepositroy;
        private readonly AreaRepository _areaRepository;
        private readonly CountryRepository _countryRepository;
        private readonly List<SelectListItem> _countrySelectList;

        public RouteController()
        {
            _routeRepository = new RouteRepository();
            _sectorRepository = new SectorRepository();
            _cragRepositroy = new CragRepository();
            _areaRepository = new AreaRepository();
            _countryRepository = new CountryRepository();

            _countrySelectList = _countryRepository.GetCountriesAsSelectList();
        }

        public ActionResult Index()
        {
            var model = _routeRepository
                .GetRoutes();
            return View(model);
        }

        //public ActionResult Index(int count)
        //{
        //    var model = _routeRepository
        //        .GetRoutes()
        //        .Take(count);
        //    return View(model);
        //}

        public ActionResult Create()
        {
            ViewBag.Countries = _countrySelectList;
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Route model)
        {
            if (ModelState.IsValid)
            {
                var route = new Route()
                {
                    Name = model.Name,
                    Grade = model.Grade,
                    SectorId = model.SectorId
                };
                _routeRepository.Add(route);
                return RedirectToAction("Index");
            }
            
            return View(model);
        }

        public ActionResult GetAreas(int? countryId)
        {
            var result = _areaRepository.GetAllAreasByCountry(countryId);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetCrags(int? areaId)
        {
            var result = _cragRepositroy.GetAllCragsByArea(areaId);
            
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetSectors(int? cragId)
        {
            var result = _sectorRepository.GetAllSectorsByCrag(cragId);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetRoutes(int? cragId)
        {
            var result = _routeRepository.GetAllRoutesBySector(cragId);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetRoutesByName(string routeName)
        {
            var model = _routeRepository.GetRoutesByName(routeName);
            return View(model);
        }
    }
}                           
