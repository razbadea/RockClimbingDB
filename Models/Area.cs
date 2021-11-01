using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RockClimbingDb.Models
{
    public class Area : RouteLocation
    {
        public int CountryId { get; set; }

        [Required(ErrorMessage = "Please enter a name")]
        [Display(Name = "Area Name:")]
        public string Name { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<Crag> Crags { get; set; }
    }
}