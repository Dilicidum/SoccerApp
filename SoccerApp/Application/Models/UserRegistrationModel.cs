using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace Application.Models
{
    public class UserRegistrationModel
    {
        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "User Name is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "Date of birth is required")]
        public DateTime DateOfBirth { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords doesn`t match")]
        public string ConfirmedPassword { get; set; }
    }
}
