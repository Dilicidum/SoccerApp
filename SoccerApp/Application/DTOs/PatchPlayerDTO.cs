using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs
{
    public class PatchPlayerDTO
    {
        public int PlayerId { get; set; }
        public string FirstName { get; set; }        
        public string LastName { get; set; }
      
        public DateTime DateOfBirth { get; set; }

        public double Sallary { get; set; }
        public string Position { get; set; }
        //public CountryDTO Country { get; set; }
    }
}
