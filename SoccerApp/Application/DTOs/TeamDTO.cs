using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DTOs
{
    public class TeamDTO
    {
        public int TeamId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int YearOfCreation { get; set; }
        public ICollection<PlayerDTO> Players { get; set; }
        public ICollection<GameDTO> Home_Games { get; set; }
        public ICollection<GameDTO> Guest_Games { get; set; }
        public ICollection<Team_LeagueDTO> Current_Leagues { get; set; }
    }
}
