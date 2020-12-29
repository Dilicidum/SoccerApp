using System;
using System.Collections.Generic;
using System.Text;
using Application.DTOs;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
using Application.Models;

namespace Application.Interfaces.Services
{
    public interface IGameService
    {
        Task<IEnumerable<GameDTO>> GetAllGames();
        Task<IEnumerable<GameDTO>> GetGamesByDate(DateTime date);
        Task<GameDTO> GetGameById(int gameId);
        Task AddGame(GameUploadModel game);
        Task UpdateGame(int GameId, GameDTO Game);
        Task DeleteAllGames();
        Task DeleteByGameId(int GameId);
        Task<GameDTO> UpdatePartially(int gameId, JsonPatchDocument<GameDTO> gameDTO);
        Task<IEnumerable<GameDTO>> GetGames_SortedByDate();
        Task<IEnumerable<GameDTO>> GetGames_SortedByGameResult();
    }
}
