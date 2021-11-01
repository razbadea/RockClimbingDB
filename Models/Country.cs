using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RockClimbingDb.Models
{
    public class Country
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter the name of the country")]
        [Display(Name = "Country Name:")]
        public string Name { get; set; }

        public virtual ICollection<Area> Areas { get; set; }
    }
}