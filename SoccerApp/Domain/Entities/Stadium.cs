using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Stadium
    {
        public int StadiumId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Max_AmountOfViewers { get; set; }
        public double Price_Per_Seat { get; set; }
        public IEnumerable<Game> Games { get; set; }
    }
}
