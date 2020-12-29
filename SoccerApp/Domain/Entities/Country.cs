using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Domain.Entities
{
    public enum Country
    {
        UK,
        France,
        Spain,
        Belgium,
        Sweden,
        Germany
    }
    public class CCountry
    {
        
        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}
