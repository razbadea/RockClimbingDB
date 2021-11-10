using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RockClimbingDb.ViewModels
{
    public class EditRouteViewModel
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

        [Display(Name = "Crag:")]
        public int CragId { get; set; }

        [Display(Name = "Area:")]
        public int AreaId { get; set; }

        [Display(Name = "Country:")]
        public int CountryId { get; set; }
    }
}