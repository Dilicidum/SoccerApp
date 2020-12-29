using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Team_League
    {
        public Team Team { get; set; }
        public int TeamId { get; set; }
        public League League { get; set; }
        public int LeagueId { get; set; }
    }
}
