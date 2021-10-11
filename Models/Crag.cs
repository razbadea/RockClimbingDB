using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RockClimbingDb.Models
{
    public class Crag
    {
        public int Id { get; set; }
        public int AreaId { get; set; }
        public string Name { get; set; }
        public string Coordinates { get; set; }
        public string Description { get; set; }
        public string Access { get; set; }

        public virtual Area Area { get; set; }
        public virtual ICollection<Sector> Sectors { get; set; }
    }
}