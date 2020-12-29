using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Team
    {
        public int TeamId { get; set; }
        public string Name { get; set; }
        public int YearOfCreation { get; set; }
        public ICollection<Player> Players { get; set; }
        public ICollection<Game> Home_Games { get; set; }
        public ICollection<Game> Guest_Games { get; set; }
        public ICollection<Team_League> Current_Leagues { get; set; }
    }
}
