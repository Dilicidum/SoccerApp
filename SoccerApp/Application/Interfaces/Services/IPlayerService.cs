using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
using Application.Models;

namespace Application.Interfaces.Services
{
    public interface IPlayerService
    {
        Task<IEnumerable<PlayerDTO>> GetAllPlayers();
        Task<IEnumerable<PlayerDTO>> GetAllPlayersByLastName(string FirstName);
        Task<IEnumerable<PlayerDTO>> GetAllPlayersByFirstName(string LastName);
        Task<IEnumerable<PlayerDTO>> GetAllPlayersByFirstNameAndLastName(string FirstName,string LastName);
        Task<PlayerDTO> GetPlayerById(int playerId);
        Task AddPlayer(PlayerUploadModel player);
        Task UpdatePlayer(int playerId,PlayerDTO player);
        Task DeleteAllPlayers();
        Task DeleteByPlayerId(int playerId);
        Task<PlayerDTO> UpdatePartially(int playerId, JsonPatchDocument<PlayerDTO> playerDTO);
    }
}
