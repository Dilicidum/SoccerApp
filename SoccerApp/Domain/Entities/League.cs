using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public enum StatusOfLeague
    {
        Local,
        International
    }
    public class League
    {
        public int LigueId { get; set; }
        public string Name { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public IEnumerable<CCountry> Countries { get; set; }
        public StatusOfLeague StatusOfLeague { get; set; }
        public IEnumerable<Game> Games { get; set; }
        public IEnumerable<Team_League> Teams { get; set; }

    }
}
