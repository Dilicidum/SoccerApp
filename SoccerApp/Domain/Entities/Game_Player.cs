using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Game_Player
    {
        public Game Game { get; set; }
        public int GameId { get; set; }
        public Player Player { get; set; }
        public int PlayerId { get; set; }
    }
}
