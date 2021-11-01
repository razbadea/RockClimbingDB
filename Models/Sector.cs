using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RockClimbingDb.Models
{
    public class Sector : RouteLocation
    {
        public int CragId { get; set; }

        [Required(ErrorMessage = "Please enter a name")]
        [Display(Name = "Sector Name:")]
        public string Name { get; set; }

        public virtual Crag Crag { get; set; }
        public virtual ICollection<Route> Routes { get; set; }
    }
}