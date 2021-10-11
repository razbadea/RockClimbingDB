using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RockClimbingDb.Models
{
    public class Route
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Grade { get; set; }
        public byte Rating { get; set; }
        public int SectorId { get; set; }

        public virtual Sector Sector { get; set; }
        public virtual ICollection<Climb> Climbs { get; set; }
    }
}