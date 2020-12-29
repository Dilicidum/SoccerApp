using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Domain.Entities;
using AutoMapper;
using Application.Interfaces.Identity;
using Application.Models;
using BLL.Models.Resources;
using Identity.Models;
using Application.Responses;
using System.Security.Claims;

namespace SoccerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController:ControllerBase
    {
        private UserManager<User> userManager;
        private SignInManager<User> signInManager;
        private IMapper mapper;
        private ITokenManager tokenManager;
        public LoginController(IMapper mapper, ITokenManager tokenManager, UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            this.tokenManager = tokenManager;
            this.mapper = mapper;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

       
        
        [HttpPost]
        public async Task<ActionResult<UserResponse>> Login(UserLoginModel userLoginModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = await userManager.FindByNameAsync(userLoginModel.UserName);

            var result = await signInManager.PasswordSignInAsync(userLoginModel.UserName,
                userLoginModel.Password, false, false);

            if (result.Succeeded)
            {
                //var user = await userManager.FindByNameAsync(userLoginModel.UserName);
                var response = await tokenManager.GenerateToken(user);
                return response;
            }
            else
            {
                return Unauthorized("Invalid User Name or Password");
            }
        }

        [HttpPost("LogOut")]
        public async Task<ActionResult> LogOut()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await userManager.FindByIdAsync(userId);
            //await userService.WriteTimeOfLogOut(user);
            await signInManager.SignOutAsync();
            return Ok();
        }
    }
}
