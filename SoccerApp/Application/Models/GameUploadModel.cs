using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Models
{
    public class GameUploadModel
    {
        public int GameId { get; set; }
        public DateTime StartTime { get; set; }
        public int House_TeamId { get; set; }
        public int Guest_TeamId { get; set; }
        public int stadiumId { get; set; }      
        public int amount_SoldTickets { get; set; }

        public string Result { get; set; }
        public string Status { get; set; }
        public string GameResult { get; set; }
        public int League_Id { get; set; }

    }
}
