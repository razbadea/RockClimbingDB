using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using RockClimbingDb.DAL;
using RockClimbingDb.Models;
using RockClimbingDb.ViewModels;

namespace RockClimbingDb.Controllers
{
    public class ClimberController : BaseController
    {
        private readonly ClimberRepository _climberRepository;
        private readonly RouteRepository _routeRepository;
        private readonly ClimbRepository _climbRepository;
        private readonly SectorRepository _sectorRepository;
        private readonly CragRepository _cragRepositroy;
        private readonly AreaRepository _areaRepository;
        private readonly CountryRepository _countryRepository;

        public ClimberController()
        {
            _climberRepository = new ClimberRepository();
            _climbRepository = new ClimbRepository();
            _routeRepository = new RouteRepository();
            _sectorRepository = new SectorRepository();
            _cragRepositroy = new CragRepository();
            _areaRepository = new AreaRepository();
            _countryRepository = new CountryRepository();
        }

        [Authorize(Roles = "User")]
        public ActionResult Climbs()
        {
            var userName = User.Identity.Name;
            var model = _climberRepository.GetUserClimbs(userName);
            return View(model);
        }



        [Authorize(Roles = "User")]
        public ActionResult AddClimb()
        {
            ViewBag.Countries = _countryRepository.GetCountriesAsSelectList();
            ViewBag.Routes = _routeRepository.GetRoutesAsSelectList(); 
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "User")]
        [ValidateAntiForgeryToken]
        public ActionResult AddClimb(Climb model)
        {
            if (ModelState.IsValid)
            {
                var climb = new Climb()
                {
                    RouteId = model.RouteId,
                    ClimberId = _climberRepository.GetClimberIdByUserId(User.Identity.GetUserId()),
                    DateOfAscent = model.DateOfAscent,
                    Style = model.Style,
                    NumberOfTries = model.NumberOfTries,
                    IsFirstAscent = model.IsFirstAscent,
                    ProposedRating = model.ProposedRating,
                    ProposedGrade = model.ProposedGrade,
                    Note = model.Note,
                };
                _climbRepository.Add(climb);
                return RedirectToAction("Climbs");
            }

            ViewBag.Routes = _routeRepository.GetRoutesAsSelectList();
            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public ActionResult EditClimb(int id) 
        {
            ViewBag.Countries = _countryRepository.GetCountriesAsSelectList();
            var model = _climbRepository.GetEditClimbViewModel(id);
            return View("EditClimb", model);
        }

        [Authorize(Roles = "User")]
        public ActionResult EditClimb(Climb model)
        {
            if (ModelState.IsValid)
            {
                _climbRepository.UpdateClimb(model);
                return RedirectToAction("Climbs");
            }
            ViewBag.Routes = _routeRepository.GetRoutesAsSelectList();
            return View(model);
        }

        [Authorize(Roles = "User")]
        public ActionResult DeleteClimb(int id)
        {
            _climbRepository.DeleteClimb(id);
            return RedirectToAction("Climbs");
        }

        [Authorize(Roles = "User")]
        public ActionResult GetClimbDetails(int id)
        {
            var climb = _climbRepository.GetClimbById(id);
            var climber = _climberRepository.GetClimberByClimberId(climb.ClimberId);
            var route = _routeRepository.GetRouteWithLocationDetailsByRouteId(climb.RouteId);
            var model = new ClimberClimbRouteViewModel()
            {
                ClimberName = $"{climber.FirstName + climber.LastName}",
                RouteName = route.Name,
                RouteSector = route.SectorName,
                RouteCrag = route.CragName,
                RouteArea = route.AreaName,
                RouteCountry = route.CountryName,
                Grade = route.Grade,
                Rating = route.Rating,
                DateOfAscent = climb.DateOfAscent,
                IsFirstAscent = climb.IsFirstAscent,
                NumberOfTries = climb.NumberOfTries,
                ProposedGrade = climb.ProposedGrade,
                Style = climb.Style,
                ProposedRating = climb.ProposedRating,
                Note = climb.Note
            };
            return View(model);
        }

    }
}
