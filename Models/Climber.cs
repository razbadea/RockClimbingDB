using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RockClimbingDb.Models
{
    public class Climber
    {
        public int Id { get; set; }
        public Guid ApplicationUserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual ICollection<Climb> Climbs { get; set; }

    }
}