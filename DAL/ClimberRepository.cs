using RockClimbingDb.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace RockClimbingDb.DAL
{
    public class ClimberRepository
    {
        public void Add(Climber climber)
        {
            using (var db = new RockClimbingDbContext())
            {
                db.Climbers.Add(climber);
                db.SaveChanges();
            }
        }

        public int GetClimberIdByUserId(string userId)
        {
            using (var db = new RockClimbingDbContext())
            {
                var climber = db.Climbers.FirstOrDefault(t => t.ApplicationUserId == userId);
                var result = climber.Id;
                return result;
            }
        }

        public List<Climb> GetUserClimbs(string userName)
        {
            using (var db = new RockClimbingDbContext())
            {

                var result =
                    db
                        .Climbs
                        //TODO Return ViewModel
                        .Include(t => t.Route)
                        .Include(t => t.Route.Sector.Crag)
                        .Include(t => t.Route.Sector.Crag.Area.Country)
                        .Where(t => t.Climber.ApplicationUser.UserName == userName)
                        //.Select(t => new Climb
                        //{
                        //    Id = t.Id,
                        //})
                        .ToList();

                return result;
            }
        }

        public Climber GetClimberByClimberId(int climberId)
        {
            using (var db = new RockClimbingDbContext())
            {
                var result = db.Climbers.FirstOrDefault(t => t.Id == climberId);
                return result;
            }
        }
    }
}