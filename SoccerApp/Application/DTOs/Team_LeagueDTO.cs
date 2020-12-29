using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs
{
    public class Team_LeagueDTO
    {
        public TeamDTO Team { get; set; }
        public int TeamId { get; set; }
        public LeagueDTO League { get; set; }
        public int LeagueId { get; set; }
    }
}
