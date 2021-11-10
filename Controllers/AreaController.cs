using RockClimbingDb.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RockClimbingDb.Controllers
{
    public class AreaController : BaseController
    {
        private readonly AreaRepository _areaRepository;

        public AreaController()
        {
            _areaRepository = new AreaRepository();
        }

        [Authorize(Roles = "User, Admin")]
        public ActionResult GetAreasByCountry(int? countryId)
        {
            var result = _areaRepository.GetAllAreasByCountry(countryId);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}