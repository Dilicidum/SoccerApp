using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using Application.Interfaces.Identity;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Application.Responses;
using Application.Models;

namespace SoccerApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegistrationController:ControllerBase
    {
        private UserManager<User> userManager;
        private IMapper mapper;
        private ITokenManager tokenManager;

        public RegistrationController(UserManager<User> userManager,IMapper mapper,ITokenManager tokenManager)
        {
            this.tokenManager = tokenManager;
            this.userManager = userManager;
            this.mapper = mapper;
        }

        [ProducesResponseType(StatusCodes.Status201Created)]

        [HttpPost]
        public async Task<ActionResult<UserResponse>> Register(UserRegistrationModel userRegistrationModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var UserFounded = await userManager.FindByNameAsync(userRegistrationModel.UserName);
            if (UserFounded == null)
            {
                User UserToBeRegistrated = mapper.Map<User>(userRegistrationModel);
                var result = await userManager.CreateAsync(UserToBeRegistrated, userRegistrationModel.Password);
                if (result.Succeeded)
                {
                    var user = await userManager.FindByNameAsync(UserToBeRegistrated.UserName);
                    var userResponse = await tokenManager.GenerateToken(user);

                    return userResponse;
                }
                else
                {
                    string i = "";
                    foreach (var x in result.Errors)
                    {
                        i += x.Description;
                    }
                    return BadRequest(i);
                }
            }
            else
            {
                return Unauthorized("UserName has already been taken");
            }
        }

        
    }
}
