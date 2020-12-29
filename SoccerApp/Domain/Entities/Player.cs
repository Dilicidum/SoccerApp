using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public enum Position
    {
        
        Goalkeeper,
        Defender,
        Midlfielder,
        Forward
    }
    public class Player
    {
        public int PlayerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public double Sallary { get; set; }
        public Position Position { get; set; }
        public CCountry Country { get; set; }
        public int? CountryId { get; set; }
        public Team Team { get; set; }
        public int? TeamId { get; set; }
    }
}
