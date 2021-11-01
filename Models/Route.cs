using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RockClimbingDb.Models
{
    public class Route
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a name")]
        [Display(Name = "Name:")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a grade")]
        [Display(Name = "Grade:")]
        public string Grade { get; set; }

        [Display(Name = "Rating:")]
        public byte Rating { get; set; }

        [Required(ErrorMessage = "Please enter a Sector")]
        [Display(Name = "Sector:")]
        public int SectorId { get; set; }

        public virtual Sector Sector { get; set; }
        public virtual ICollection<Climb> Climbs { get; set; }
    }
}