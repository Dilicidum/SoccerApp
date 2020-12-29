using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace Application.DTOs
{
    public class PlayerDTO
    {
        public int PlayerId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        
        [Required]
        public double Sallary { get; set; }
        public string Position { get; set; }
        [Required]
        public CountryDTO Country { get; set; }
        
        public TeamDTO Team { get; set; }
        public int TeamId { get; set; }

    }
}
