using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Application.Responses;
using Domain.Entities;
namespace Application.Interfaces.Identity
{
    public interface ITokenManager
    {
        Task<UserResponse> GenerateToken(User user);
    }
}
