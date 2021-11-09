using RockClimbingDb.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RockClimbingDb.ViewModels
{
    public class RouteDetailsViewModel
    {
        [Display(Name = "Name:")]
        public string Name { get; set; }

        [Display(Name = "Grade:")]
        public string Grade { get; set; }

        [Display(Name = "Rating:")]
        public byte Rating { get; set; }

        [Display(Name = "Sector:")]
        public string SectorName { get; set; }

        [Display(Name = "Crag:")]
        public string CragName { get; set; }

        [Display(Name = "Area:")]
        public string AreaName { get; set; }

        [Display(Name = "Country:")]
        public string CountryName{ get; set; }

    }
}