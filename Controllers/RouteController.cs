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
        private readonly CragRepository _cragRepository;
        private readonly AreaRepository _areaRepository;
        private readonly CountryRepository _countryRepository;
        private readonly List<SelectListItem> _countrySelectList;

        public RouteController()
        {
            _routeRepository = new RouteRepository();
            _sectorRepository = new SectorRepository();
            _cragRepository = new CragRepository();
            _areaRepository = new AreaRepository();
            _countryRepository = new CountryRepository();

            _countrySelectList = _countryRepository.GetCountriesAsSelectList();
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            var model = _routeRepository
                .GetRoutes();
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.Countries = _countrySelectList;
            return View();
        }

        [Authorize(Roles = "Admin")]
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


        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            ViewBag.Countries = _countryRepository.GetCountriesAsSelectList();
            var model = _routeRepository.GetEditRouteViewModelByRouteId(id);
            return View("Edit", model);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Edit(Route model)
        {
            if (ModelState.IsValid)
            {
                _routeRepository.UpdateRoute(model);
                return RedirectToAction("Index");
            }
            ViewBag.Routes = _routeRepository.GetRoutesAsSelectList();
            return View(model);
        }

        [Authorize(Roles = "User, Admin")]
        public ActionResult GetRoutesBySector(int? sectorId)
        {
            var result = _routeRepository.GetAllRoutesBySector(sectorId);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [Authorize(Roles = "User, Admin")]
        public ActionResult GetRoutesByName(string routeName)
        {
            var model = _routeRepository.GetRoutesByName(routeName);
            return View(model);
        }
    }
}                           
