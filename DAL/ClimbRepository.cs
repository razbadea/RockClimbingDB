using RockClimbingDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using System.Net;
using RockClimbingDb.ViewModels;

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

        public Climb GetClimbById(int id)
        {
            using (var db = new RockClimbingDbContext())
            {
                var result = db.Climbs.Find(id);
                return result;
            }

        }

        public void DeleteClimb(int id)
        {
            using (var db = new RockClimbingDbContext())
            {
                var climb = db.Climbs.FirstOrDefault(t => t.Id == id);
                db.Climbs.Remove(climb);
                db.SaveChanges();
            }
        }

        public EditClimbViewModel GetEditClimbViewModel(int id)
        {
            using (var db = new RockClimbingDbContext())
            {
                var climb = db.Climbs.Find(id);
                EditClimbViewModel result = new EditClimbViewModel()
                { 
                    Id = climb.Id,
                    RouteId = climb.RouteId,
                    ClimberId = climb.ClimberId,
                    DateOfAscent = climb.DateOfAscent,
                    Style = climb.Style,
                    NumberOfTries = climb.NumberOfTries,
                    IsFirstAscent = climb.IsFirstAscent,
                    ProposedGrade = climb.ProposedGrade,
                    ProposedRating = climb.ProposedRating,
                    Note = climb.Note,
                    SectorId = climb.Route.SectorId,
                    CragId = climb.Route.Sector.CragId,
                    AreaId = climb.Route.Sector.Crag.AreaId,
                    CountryId = climb.Route.Sector.Crag.Area.CountryId,                   
                };
                return result;
            }
        }

        public List<LatestClimbsViewModel> GetLatestClimbsViewModel(int count)
        {
            using ( var db = new RockClimbingDbContext())
            {
                var latestClimbs = db.Climbs.OrderByDescending(t => t.DateOfAscent).Take(count).ToList();
                List<LatestClimbsViewModel> result = new List<LatestClimbsViewModel>();
                foreach (var climb in latestClimbs)
                {
                    LatestClimbsViewModel viewModel = new LatestClimbsViewModel()
                    {
                        RouteName = climb.Route.Name,
                        ClimberName = $"{climb.Climber.FirstName} {climb.Climber.LastName}",
                        DateOfAscent = climb.DateOfAscent,
                        Grade = climb.Route.Grade,
                        Crag = climb.Route.Sector.Crag.Name
                    };
                    result.Add(viewModel);
                }
                return result;
            }
        }

        public void UpdateClimb(Climb climb)
        {
            using (var db = new RockClimbingDbContext())
            {
                var dbClimb = db.Climbs.FirstOrDefault(t => t.Id == climb.Id);
                if (dbClimb != null)
                {
                    dbClimb.RouteId = climb.RouteId;
                    dbClimb.ClimberId = climb.ClimberId;
                    dbClimb.DateOfAscent = climb.DateOfAscent;
                    dbClimb.Style = climb.Style;
                    dbClimb.IsFirstAscent = climb.IsFirstAscent;
                    dbClimb.ProposedGrade = climb.ProposedGrade;
                    dbClimb.ProposedRating = climb.ProposedRating;
                    dbClimb.Note = climb.Note;
                    db.SaveChanges();
                }
            }
        }
    }
}