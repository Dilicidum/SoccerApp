using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
namespace Application.Interfaces.Services
{
    public interface ITeamService
    {
        Task<IEnumerable<TeamDTO>> GetAllTeams(string Name = null);
        Task<TeamDTO> GetTeamById(int teamId);
        Task AddTeam(TeamDTO teamDTO);
        Task UpdateTeam(int teamId,TeamDTO teamDTO);
        Task DeleteAllTeams();
        Task DeleteTeamById(int teamId);
        Task<TeamDTO> UpdatePartially(int teamId,JsonPatchDocument<TeamDTO> teamDTO);
        Task<IEnumerable<GameDTO>> GetGamesByStatus(int teamId,string status);
        Task<IEnumerable<GameDTO>> GetGamesByDate(int teamId,DateTime date);
    }
}
