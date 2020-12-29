using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs
{
    public class StadiumDTO
    {
        public int StadiumId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Max_AmountOfViewers { get; set; }
        public double Price_Per_Seat { get; set; }
        public IEnumerable<GameDTO> Games { get; set; }
    }
}
