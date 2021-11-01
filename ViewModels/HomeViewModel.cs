using RockClimbingDb.Models;
using System.Collections.Generic;


namespace RockClimbingDb.ViewModels
{
    public class HomeViewModel
    {
        public HomeViewModel()
        {
            LatestClimbs = new List<Climb>();
            RandomHighRatedClimbs = new List<Climb>();
        }

        public List<Climb> LatestClimbs { get; set; }
        public List<Climb> RandomHighRatedClimbs { get; set; }
        public Crag CragOfTheDay { get; set; }

    }
}