using System;
using System.Collections.Generic;
using System.Text;
using Application.DTOs;
using System.ComponentModel.DataAnnotations;
namespace Application.Models
{
    public class PlayerUploadModel
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
    }
}
