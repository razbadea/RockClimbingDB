using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RockClimbingDb.Models
{
    public class Sector
    {
        public int Id { get; set; }
        public int CragId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Access { get; set; }

        public virtual Crag Crag { get; set; }
        public virtual ICollection<Route> Routes { get; set; }
    }
}