using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using RockClimbingDb.DAL;
using RockClimbingDb.Models;


namespace RockClimbingDb.Controllers
{
    public class ClimberController : BaseController
    {
        private readonly ClimberRepository _climberRepository;
        private readonly RouteRepository _routeRepository;
        private readonly ClimbRepository _climbRepository;
        private readonly List<SelectListItem> _routeSelectList;
        public ClimberController()
        {
            _climberRepository = new ClimberRepository();
            _routeRepository = new RouteRepository();
            _climbRepository = new ClimbRepository();
            _routeSelectList = _routeRepository.GetRoutesAsSelectList();
        }
        public ActionResult Climbs()
        {
            var userName = User.Identity.Name;
            var model = _climberRepository.GetUserClimbs(userName);
            return View(model);
        }

        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult AddClimb()
        {
            ViewBag.Routes = _routeSelectList;
            return View();
        }

        // POST: /Climber/Register
        [HttpPost]

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
           
            ViewBag.Routes = _routeSelectList;
            return View(model);
        }
    }
}
