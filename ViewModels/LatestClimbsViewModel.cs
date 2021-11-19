using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RockClimbingDb.ViewModels
{
    public class LatestClimbsViewModel
    {
        [Display(Name = "Route Name:")]
        public string RouteName { get; set; }

        [Display(Name = "Grade:")]
        public string Grade { get; set; }

        [Display(Name = "Climber Name:")]
        public string ClimberName { get; set; }

        [Display(Name = "Date of Ascent:")]
        public DateTime DateOfAscent { get; set; }

        [Display(Name = "Crag:")]
        public String Crag { get; set; }
    }
}