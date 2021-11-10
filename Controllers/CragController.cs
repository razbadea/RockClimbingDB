using RockClimbingDb.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RockClimbingDb.Controllers
{
    public class CragController : BaseController
    {
        private readonly CragRepository _cragRepository;

        public CragController()
        {
            _cragRepository = new CragRepository();
        }

        [Authorize(Roles = "User, Admin")]
        public ActionResult GetCragsByArea(int? areaId)
        {
            var result = _cragRepository.GetAllCragsByArea(areaId);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}