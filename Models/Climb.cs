using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RockClimbingDb.Models
{
    public class Climb
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter route name")]
        [Display(Name = "Route Name:")]
        public int RouteId { get; set; }

        public int ClimberId { get; set; }

        [Required(ErrorMessage = "Please enter the date of the ascent")]
        [Display(Name = "Date of Ascent:")]
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

        public virtual Climber Climber { get; set; }
        public virtual Route Route { get; set; }
    }
}