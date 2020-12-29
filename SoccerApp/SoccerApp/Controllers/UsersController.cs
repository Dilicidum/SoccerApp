using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Application.DTOs;
namespace API.Controllers
{
    [ApiController]
    [Route("api/Users")]
    public class UsersController : ControllerBase
    {
        private IMapper mapper;
        private UserManager<User> userManager;

        public UsersController(IMapper mapper, UserManager<User> userManager)
        {
            this.mapper = mapper;
            this.userManager = userManager;
        }

        

        [HttpGet("UserNameIsUnique")]
        public async Task<ActionResult<bool>> UserNameIsUnique([FromQuery] string UserName)
        {
            var user = await userManager.FindByNameAsync(UserName);
            if (user == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [HttpGet("{Id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<UserDTO>> GetUserInfo(string Id)
        {
            var user = await userManager.FindByIdAsync(Id);
            UserDTO userDTO = mapper.Map<UserDTO>(user);
            return userDTO;
        }
    }
}