using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RockClimbingDb.Models
{
    public class RouteLocation
    {
        public int Id { get; set; }


        [Display(Name = "Description:")]
        public string Description { get; set; }

        [Display(Name = "Access:")]
        public string Access { get; set; }
    }
}