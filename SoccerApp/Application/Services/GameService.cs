using Application.DTOs;
using Application.Interfaces.Persistence;
using Application.Interfaces.Services;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.AspNetCore.JsonPatch;
using System.Linq;
using Application.Models;

namespace Application.Services
{
    public class GameService : IGameService
    {
        private IUnitOfWork unitOfWork;
        private IMapper mapper;

        public GameService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;

        }
        public async Task AddGame(GameUploadModel gameModel)
        {
            var Game = mapper.Map<Game>(gameModel);
            
            
            await unitOfWork.GameRepository.AddAsync(Game);
            await unitOfWork.Commit();
        }

        public async Task DeleteAllGames()
        {
            var Games = await unitOfWork.GameRepository.GetAllAsync();
            unitOfWork.GameRepository.RemoveRange(Games);
            await unitOfWork.Commit();
        }

        public async Task DeleteByGameId(int GameId)
        {
            var playerToDelete = await unitOfWork.GameRepository.GetByIdAsync(GameId);
            unitOfWork.GameRepository.Remove(playerToDelete);
            await unitOfWork.Commit();
        }

        public async Task<IEnumerable<GameDTO>> GetAllGames()
        {
            var games = await unitOfWork.GameRepository.GetGamesWithDetails();
            var gamesDTO = mapper.Map<IEnumerable<GameDTO>>(games);
            return gamesDTO;
        }

        public async Task<GameDTO> GetGameById(int gameId)
        {
            var game = await unitOfWork.GameRepository.GetByIdAsync(gameId);
            var gameDTO = mapper.Map<GameDTO>(game);
            return gameDTO;
        }

        public async Task<IEnumerable<GameDTO>> GetGamesByDate(DateTime date)
        {
            var games = await unitOfWork.GameRepository.GetGamesWithDetails(game => game.TimeStart == date);
            var gamesDTO = mapper.Map<IEnumerable<GameDTO>>(games);
            return gamesDTO;
        }

        public async Task<IEnumerable<GameDTO>> GetGames_SortedByDate()
        {
            var games = await unitOfWork.GameRepository.GetGamesWithDetails();
            var gamesDTO = mapper.Map<IEnumerable<GameDTO>>(games);
            return gamesDTO.OrderBy(c => c.StartTime);
        }

        public async Task<IEnumerable<GameDTO>> GetGames_SortedByGameResult()
        {
            var games = await unitOfWork.GameRepository.GetGamesWithDetails();
            var gamesDTO = mapper.Map<IEnumerable<GameDTO>>(games);
            return gamesDTO.OrderBy(c => c.GameResult);
        }

        public async Task UpdateGame(int GameId, GameDTO GameDTO)
        {
            var Game = mapper.Map<Player>(GameDTO);
            Game.PlayerId = GameId;
            unitOfWork.PlayerRepository.Update(Game);
            await unitOfWork.Commit();
        }

        public async Task<GameDTO> UpdatePartially(int gameId, JsonPatchDocument<GameDTO> gameDTODoc)
        {
            var game = await unitOfWork.GameRepository.GetByIdAsync(gameId);
            var gameDTO = mapper.Map<GameDTO>(game);
            gameDTODoc.ApplyTo(gameDTO);
            mapper.Map(gameDTO, game);
            unitOfWork.GameRepository.Update(game);
            await unitOfWork.Commit();
            return gameDTO;
        }
    }
}
