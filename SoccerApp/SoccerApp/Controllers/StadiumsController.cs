using Application.Interfaces.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using Microsoft.AspNetCore.JsonPatch;
namespace SoccerApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StadiumsController:ControllerBase
    {
        public IStadiumService stadiumService;
        public StadiumsController(IStadiumService stadiumService)
        {
            this.stadiumService = stadiumService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StadiumDTO>>> GetAllPlayers([FromQuery] string Name = null)
        {
            var players = await stadiumService.GetAllStadiums(Name);
            return players.ToList();
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> AddPlayer([FromBody] StadiumDTO Stadium)
        {
            await stadiumService.AddStadium(Stadium);
            return Ok();
        }

        [HttpDelete]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> DeleteAll()
        {
            await stadiumService.DeleteAllStadiums();
            return Ok();
        }

        [HttpGet("{stadiumId}")]
        public async Task<ActionResult<StadiumDTO>> GetPlayerById(int stadiumId)
        {
            var Stadium = await stadiumService.GetStadiumById(stadiumId);
            if (Stadium == null)
            {
                return NotFound();
            }
            return Stadium;
        }

        [HttpPut("{stadiumId}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> UpdatePlayer(int stadiumId, StadiumDTO Stadium)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await stadiumService.UpdateStadium(stadiumId, Stadium);
            return NoContent();
        }

        [HttpDelete("{stadiumId}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> DeletePlayerById(int stadiumId)
        {
            await stadiumService.DeleteStadiumById(stadiumId);
            return Ok();
        }

        [HttpPatch("{stadiumId}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> PatchPlayer(int stadiumId, JsonPatchDocument<StadiumDTO> stadiumDTO)
        {
            if (stadiumDTO != null)
            {
                var res = await stadiumService.UpdatePartially(stadiumId, stadiumDTO);

                var team = await stadiumService.GetStadiumById(stadiumId);

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                return Ok(res);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

    }
}
