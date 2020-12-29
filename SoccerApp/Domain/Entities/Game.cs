using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace Domain.Entities
{
    public enum GameStatus
    {
        NotPlayedYet,
        Active,
        Postponed,
        Completed,
    }

    public enum GameResult
    {
        NotPlayed,
        Win,
        Loss,
        Draw
    }

    public class Game
    {

        public int GameId { get; set; }
        public DateTime TimeStart { get; set; }
        
        [ForeignKey("House_Team_Id")]
        public Team House_Team { get; set; }
        public int House_Team_Id { get; set; }
        [ForeignKey("Guest_Team_Id")]
        public Team Guest_Team { get; set; }
        
        public int Guest_Team_Id { get; set; }

        public Stadium Stadium { get; set; }
        public int Stadium_Id { get; set; }
        public int Amount_SoldTickets { get; set; }
        public string Result { get; set; }
        public GameStatus Status { get; set; }
        public GameResult GameResult { get; set; }
        public League League { get; set; }
        public int LeagueId { get; set; }
        

    }
}
