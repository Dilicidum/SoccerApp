using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;
using Application.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
namespace SoccerApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GamesController:ControllerBase
    {
        private IGameService gameService;

        public GamesController(IGameService gameService)
        {
            this.gameService = gameService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameDTO>>> GetAllGames()
        {
            var games = await gameService.GetAllGames();
            return games.ToList();
        }

        [HttpPost]
        public async Task<ActionResult> AddGames([FromBody] GameUploadModel game)
        {
            await gameService.AddGame(game);
            ///return CreatedAtAction(nameof(GetGameById),game);
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteAll()
        {
            await gameService.DeleteAllGames();
            return Ok();
        }


        [HttpGet("{gameId}")]
        public async Task<ActionResult<GameDTO>> GetGameById(int gameId)
        {
            var game = await gameService.GetGameById(gameId);
            if (game == null)
            {
                return NotFound();
            }
            return game;
        }

        [HttpPut("{gameId}")]
        public async Task<ActionResult> UpdateGame(int gameId, GameDTO game)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await gameService.UpdateGame(gameId, game);
            return NoContent();
        }

        [HttpDelete("{gameId}")]
        public async Task<ActionResult> DeleteGameById(int gameId)
        {
            await gameService.DeleteByGameId(gameId);
            return Ok();
        }

        [HttpPatch("{gameId}")]
        public async Task<ActionResult> PatchPlayer(int gameId, JsonPatchDocument<GameDTO> gameDTO)
        {
            if (gameDTO != null)
            {
                var res = await gameService.UpdatePartially(gameId, gameDTO);

                var team = await gameService.GetGameById(gameId);

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

        [HttpGet("DateSorted")]
        public async Task<ActionResult<IEnumerable<GameDTO>>> GetGamesSortedByDate()
        {
            var games = await gameService.GetGames_SortedByDate();
            return games.ToList();
        }

        [HttpGet("ResultSorted")]
        public async Task<ActionResult<IEnumerable<GameDTO>>> GetGamesSortedByResult()
        {
            var games = await gameService.GetGames_SortedByGameResult();
            return games.ToList();
        }
    }
}
