using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;
using AutoMapper;
using Application.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
namespace SoccerApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayersController:ControllerBase
    {
        IPlayerService playerService;
        IMapper mapper;
        public PlayersController(IPlayerService playerService,IMapper mapper)
        {
            this.mapper = mapper;
            this.playerService = playerService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlayerDTO>>> GetAllPlayers([FromQuery] string FirstName = null,
            [FromQuery]string LastName = null)
        {
            IEnumerable<PlayerDTO> players;
            if(FirstName == null && LastName != null)
            {
                players = await playerService.GetAllPlayersByLastName(LastName);
            }
            else if(LastName == null && FirstName != null)
            {
                players = await playerService.GetAllPlayersByFirstName(FirstName);
            }
            else if(LastName != null && FirstName != null)
            {
                players = await playerService.GetAllPlayersByFirstNameAndLastName(FirstName, LastName);
            }
            else
            {
                players = await playerService.GetAllPlayers();
            }
            
            return players.ToList();
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> AddPlayer(PlayerUploadModel player)
        {
            await playerService.AddPlayer(player);
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteAll()
        {
            await playerService.DeleteAllPlayers();
            return Ok();
        }

        [HttpGet("{playerId}")]
        public async Task<ActionResult<PlayerDTO>> GetPlayerById(int playerId)
        {
            var player = await playerService.GetPlayerById(playerId);
            if (player == null)
            {
                return NotFound();
            }
            return player;
        }

        [HttpPut("{playerId}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> UpdatePlayer(int playerId,PlayerDTO player)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await playerService.UpdatePlayer(playerId, player);
            return NoContent();
        }

        [HttpDelete("{playerId}")]
        public async Task<ActionResult> DeletePlayerById(int playerId)
        {
            await playerService.DeleteByPlayerId(playerId);
            return Ok();
        }

        [HttpPatch("{playerId}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> PatchPlayer(int playerId, JsonPatchDocument<PlayerDTO> playerDTO)
        {
            
            if (playerDTO != null)
            {
                var res = await playerService.UpdatePartially(playerId, playerDTO);

                var team = await playerService.GetPlayerById(playerId);

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
