using RockClimbingDb.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RockClimbingDb.Controllers
{
    public class SectorController : BaseController
    {
        private readonly SectorRepository _sectorRepository;

        public SectorController()
        {
            _sectorRepository = new SectorRepository();
        }

        [Authorize(Roles = "User, Admin")]
        public ActionResult GetSectorsByCrag(int? cragId)
        {
            var result = _sectorRepository.GetAllSectorsByCrag(cragId);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}