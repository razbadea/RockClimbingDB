using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static RockClimbingDb.Common.ClimbEnums;

namespace RockClimbingDb.ViewModels
{
    public class ClimberClimbRouteViewModel
    {
        public string ClimberName { get; set; }
        public DateTime DateOfAscent { get; set; }

        [Required(ErrorMessage = "Please enter the style of the ascent")]
        [Display(Name = "Style:")]
        public string Style { get; set; }

        [Display(Name = "Number Of Tries:")]
        public int? NumberOfTries { get; set; }

        [Display(Name = "Is this a first Ascent?:")]
        public byte IsFirstAscent { get; set; }

        [Display(Name = "Proposed Rating:")]
        public byte ProposedRating { get; set; }

        [Display(Name = "Proposed Grade:")]
        public string ProposedGrade { get; set; }

        [Display(Name = "Note:")]
        public string Note { get; set; }

        [Required(ErrorMessage = "Please enter a name")]
        [Display(Name = "Name:")]
        public string RouteName { get; set; }

        [Required(ErrorMessage = "Please enter a grade")]
        [Display(Name = "Grade:")]
        public string Grade { get; set; }
        public Grade GradeEnum => (Grade)Enum.Parse(typeof(Grade), Grade);

        [Display(Name = "Rating:")]
        public byte Rating { get; set; }

        [Display(Name = "Sector:")]
        public string RouteSector { get; set; }

        [Display(Name = "Crag:")]
        public string RouteCrag { get; set; }

        [Display(Name = "Area:")]
        public string RouteArea { get; set; }

        [Display(Name = "Country:")]
        public string RouteCountry { get; set; }

    }
}