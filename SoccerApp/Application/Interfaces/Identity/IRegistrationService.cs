using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
namespace Application.Interfaces.Identity
{
    public interface IRegistrationService
    {
        Task<string> RegisterUser(UserRegistrationModel userRegistrationModel);
    }
}
