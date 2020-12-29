using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace Application.Interfaces.Services
{
    public interface IEmailService
    {
        Task<bool> CheckEmailAlreadyTaken(string email);
    }
}
