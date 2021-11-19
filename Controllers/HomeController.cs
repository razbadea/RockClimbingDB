using RockClimbingDb.DAL;
using RockClimbingDb.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RockClimbingDb.Controllers
{
    public class HomeController : Controller
    {        
        private readonly ClimbRepository _climbRepository;
        public HomeController()
        {
            _climbRepository = new ClimbRepository();
        }

        public ActionResult Index()
        {
            var model = _climbRepository.GetLatestClimbsViewModel(5);
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}