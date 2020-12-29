using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs
{
    public class LeagueDTO
    {
        public int LigueId { get; set; }
        public string Name { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public IEnumerable<CountryDTO> Countries { get; set; }
        public string StatusOfLeague { get; set; }
        public IEnumerable<GameDTO> Games { get; set; }
        public IEnumerable<Team_LeagueDTO> Teams { get; set; }
    }
}
