using Application.DTOs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
namespace SoccerApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamsController : ControllerBase
    {
        private ITeamService teamService;
        public TeamsController(ITeamService teamService)
        {
            this.teamService = teamService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeamDTO>>> GetAllTeams([FromQuery] string Name)
        {
            if (Name == null)
            {
                var teams = await teamService.GetAllTeams();
                return teams.ToList();
            }
            else
            {
                var teams = await teamService.GetAllTeams(Name);
                return teams.ToList();
            }


        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public async Task<ActionResult> AddTeam(TeamDTO team)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await teamService.AddTeam(team);
            return Ok();
            
        }

        [HttpGet("{teamId}")]
        public async Task<TeamDTO> GetTeamById(int teamId)
        {
            var team = await teamService.GetTeamById(teamId);
            return team;
        }

        [HttpGet("{teamId}/Date")]
        public async Task<ActionResult<IEnumerable<GameDTO>>> GetLast(int teamId, DateTime dateTime)
        {
            var result = await teamService.GetGamesByDate(teamId, dateTime);
            if(result != null)
            {
                return result.ToList();
            }
            else
            {
                return BadRequest();
            }
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut("teamId")]
        public async Task<ActionResult> UpdateTeam(int teamId, TeamDTO team)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await teamService.UpdateTeam(teamId, team);
            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteAll()
        {
            await teamService.DeleteAllTeams();
            return Ok();
        }

        [HttpDelete("teamId")]
        public async Task<ActionResult> DeleteById(int teamId)
        {
            await teamService.DeleteTeamById(teamId);
            return Ok();
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPatch("{teamId}")]
        public async Task<ActionResult> PatchPlayer(int teamId, JsonPatchDocument<TeamDTO> teamDTO)
        {
            if (teamDTO != null)
            {
                var res = await teamService.UpdatePartially(teamId, teamDTO);

                var team = await teamService.GetTeamById(teamId);

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

        [HttpGet("{teamId}/Won")]
        public async Task<ActionResult<IEnumerable<GameDTO>>> GetWonGamesByTeamId(int teamId)
        {
            var games = await teamService.GetGamesByStatus(teamId, "Win");
            return games.ToList();
        }

        [HttpGet("{teamId}/Loss")]
        public async Task<ActionResult<IEnumerable<GameDTO>>> GetLossGamesByTeamId(int teamId)
        {
            var games = await teamService.GetGamesByStatus(teamId, "Loss");
            return games.ToList();
        }

        [HttpGet("{teamId}/Draw")]
        public async Task<ActionResult<IEnumerable<GameDTO>>> GetDrawGamesByTeamId(int teamId)
        {
            var games = await teamService.GetGamesByStatus(teamId, "Draw");
            return games.ToList();
        }

        [HttpGet("{teamId}/UnPlayed")]
        public async Task<ActionResult<IEnumerable<GameDTO>>> GetNotPlayedGamesByTeamId(int teamId)
        {
            var games = await teamService.GetGamesByStatus(teamId, "NotPlayed");
            return games.ToList();
        }
    }
}
