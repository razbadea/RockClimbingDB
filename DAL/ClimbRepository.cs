using RockClimbingDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;

namespace RockClimbingDb.DAL
{
    public class ClimbRepository
    {
        public List<Climb> GetLastestClimbs(int numberOfClimbs)
        {

            List<Climb> result;
            using (var db = new RockClimbingDbContext())
            {
                result =
                    db
                        .Climbs
                        .OrderByDescending(t => t.DateOfAscent)
                        .Take(numberOfClimbs)
                        .ToList();
            }
            return result;
        }

        public List<Climb> GetClimbsByUserId(int userId)
        {
            List<Climb> result;
            using (var db = new RockClimbingDbContext())
            {
                result = db
                    .Climbs
                    .Include(t => t.Route)
                    .Where(t => t.ClimberId == userId)
                    .ToList();
            }
            return result;
        }

        public void Add(Climb climb)
        {
            using (var db = new RockClimbingDbContext())
            {
                db.Climbs.Add(climb);
                db.SaveChanges();
            }
        }
    }
}