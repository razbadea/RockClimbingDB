using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RockClimbingDb.Models
{
    public class Area
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Access { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<Crag> Crags { get; set; }
    }
}