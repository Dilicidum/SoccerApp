using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs
{
    public class GameDTO
    {
        public int GameId { get; set; }
        public DateTime StartTime { get; set; }
        public TeamDTO House_Team { get; set; }
        public int House_Team_Id { get; set; }
        
        public TeamDTO Guest_Team { get; set; }
        public int Guest_Team_Id { get; set; }
        public StadiumDTO Stadium { get; set; }
        public int Stadium_Id { get; set; }
        public int Amount_SoldTickets { get; set; }
        public string Result { get; set; }
        public string Status { get; set; }
        public string GameResult { get; set; }
        public LeagueDTO League { get; set; }
        public int LeagueId { get; set; }
    }
}
