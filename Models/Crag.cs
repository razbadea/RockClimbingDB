using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RockClimbingDb.Models
{
    public class Crag : RouteLocation
    {
        public int AreaId { get; set; }

        [Required(ErrorMessage = "Please enter a name")]
        [Display(Name = "Crag Name:")]
        public string Name { get; set; }

        public virtual Area Area { get; set; }
        public virtual ICollection<Sector> Sectors { get; set; }
    }
}