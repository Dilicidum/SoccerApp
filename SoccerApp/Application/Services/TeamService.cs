using Application.DTOs;
using Application.Interfaces.Persistence;
using Application.Interfaces.Services;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class TeamService : ITeamService
    {
        private IMapper mapper;
        private IUnitOfWork unitOfWork;
        public TeamService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task AddTeam(TeamDTO teamDTO)
        {
            var team = mapper.Map<Team>(teamDTO);
            await unitOfWork.TeamRepository.AddAsync(team);
            await unitOfWork.Commit();
        }

        public async Task DeleteAllTeams()
        {
            var teams = await unitOfWork.TeamRepository.GetAllAsync();
            unitOfWork.TeamRepository.RemoveRange(teams);
            await unitOfWork.Commit();
        }

        public async Task DeleteTeamById(int teamId)
        {
            var team = await unitOfWork.TeamRepository.GetByIdAsync(teamId);
            unitOfWork.TeamRepository.Remove(team);
            await unitOfWork.Commit();
        }

        public async Task<IEnumerable<TeamDTO>> GetAllTeams(string Name)
        {
            if(Name != null)
            {
                var teams = await unitOfWork.TeamRepository.GetTeamsWithDetails(team => team.Name == Name);
                var teamsDTO = mapper.Map<IEnumerable<TeamDTO>>(teams);
                return teamsDTO;
            }
            else
            {
                var teams = await unitOfWork.TeamRepository.GetTeamsWithDetails();
                var teamsDTO = mapper.Map<IEnumerable<TeamDTO>>(teams);
                return teamsDTO;
            }
        }

        public async Task<IEnumerable<GameDTO>> GetGamesByDate(int teamId, DateTime date)
        {
            var teams = await unitOfWork.TeamRepository.GetTeamsWithDetails();
            var team = teams.Where(c => c.TeamId == teamId).FirstOrDefault();
            if (team.Home_Games.Any())
            {
                var games = team.Home_Games.Where(c => c.TimeStart == date).ToList();
                var gamesDTO = mapper.Map<IEnumerable<GameDTO>>(games);
                return gamesDTO;
            }
            return null;
        }

        public async Task<IEnumerable<GameDTO>> GetGamesByStatus(int teamId,string status)
        {
            List<Game> games = new List<Game>();
            GameResult gameResult;
            var team = (await unitOfWork.TeamRepository.GetAsync(team => team.TeamId == teamId)).SingleOrDefault();
                
            switch (status)
            {
                case "Win":
                    gameResult = GameResult.Win;
                    break;
                case "Loss":
                    gameResult = GameResult.Loss;
                    break;
                case "Draw":
                    gameResult = GameResult.Draw;
                    break;
                case "NotPlayed":
                    gameResult = GameResult.NotPlayed;
                    break;
                default: gameResult = 0;
                    break;
            }
            if (team != null && gameResult != 0)
            {
                foreach(var game in team.Guest_Games)
                {
                    if(game.GameResult == gameResult)
                    {
                        games.Add(game);
                    }
                }

                foreach(var game in team.Home_Games)
                {
                    if (game.GameResult == gameResult)
                    {
                        games.Add(game);
                    }
                }
                
            }
            var gamesDTO = mapper.Map <IEnumerable<GameDTO>>(games);
            return gamesDTO;
        }

        public async Task<TeamDTO> GetTeamById(int teamId)
        {
            var team = await unitOfWork.TeamRepository.GetByIdAsync(teamId);
            var teamDTO = mapper.Map<TeamDTO>(team);
            return teamDTO;
        }

        public async Task<TeamDTO> UpdatePartially(int teamId, JsonPatchDocument<TeamDTO> teamDTODoc)
        {
            var team = await unitOfWork.TeamRepository.GetByIdAsync(teamId);
            var teamDTO = mapper.Map<TeamDTO>(team);
            teamDTODoc.ApplyTo(teamDTO);
            mapper.Map(teamDTO, team); 
            unitOfWork.TeamRepository.Update(team); 
            await unitOfWork.Commit();
            return teamDTO;
        }

        public async Task UpdateTeam(int teamId, TeamDTO teamDTO)
        {
            var team = mapper.Map<Team>(teamDTO);
            unitOfWork.TeamRepository.Update(team);
            await unitOfWork.Commit(); 
        }
    }
}
