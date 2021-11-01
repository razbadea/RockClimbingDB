using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RockClimbingDb.Models
{
    public class Climber
    {
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }

        [Required(ErrorMessage = "Please enter your First Name")]
        [Display(Name = "First Name:")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your Last Name")]
        [Display(Name = "Last Name:")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter your Date of Birth")]
        [Display(Name = "Date of birth:")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Please enter your email")]
        [Display(Name = "Email:")]
        public string Email { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual ICollection<Climb> Climbs { get; set; }

    }
}