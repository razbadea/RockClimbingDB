using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RockClimbingDb.Models
{
    public class Climb
    {
        public int Id { get; set; }
        public int RouteId { get; set; }
        public int ClimberId { get; set; }
        public DateTime DateOfAscent { get; set; }
        public string Style { get; set; }
        public int? NumberOfTries { get; set; }
        public byte IsFirstAscent { get; set; }
        public byte ProposedRating { get; set; }
        public string ProposedGrade { get; set; }
        public string Note { get; set; }

        public virtual Climber Climber { get; set; }
        public virtual Route Route { get; set; }
    }
}