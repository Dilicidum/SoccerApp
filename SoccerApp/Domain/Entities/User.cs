using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities
{
    public class User:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfRegistration { get; set; }
        public DateTime DateOfLastActivity { get; set; }
    }
}
