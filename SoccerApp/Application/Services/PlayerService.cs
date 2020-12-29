using Application.DTOs;
using Application.Interfaces.Persistence;
using Application.Interfaces.Services;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
using Application.Models;

namespace Application.Services
{
    public class PlayerService : IPlayerService
    {
        IUnitOfWork unitOfWork;
        IMapper mapper;
        public PlayerService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task AddPlayer(PlayerUploadModel playerDTO)
        {
            var player = mapper.Map<Player>(playerDTO);
            await unitOfWork.PlayerRepository.AddAsync(player);
            await unitOfWork.Commit();
        }

        public async Task DeleteAllPlayers()
        {
            var players = await unitOfWork.PlayerRepository.GetAllAsync();
            unitOfWork.PlayerRepository.RemoveRange(players);
            await unitOfWork.Commit();
        }

        public async Task DeleteByPlayerId(int playerId)
        {
            var playerToDelete = await unitOfWork.PlayerRepository.GetByIdAsync(playerId);
            unitOfWork.PlayerRepository.Remove(playerToDelete);
            await unitOfWork.Commit();
        }

        public async Task<IEnumerable<PlayerDTO>> GetAllPlayers(string FirstName,string LastName)
        {
            var players = await unitOfWork.PlayerRepository.GetAsync(x => x.FirstName == FirstName && x.LastName == LastName);
            var playersDTO = mapper.Map<IEnumerable<PlayerDTO>>(players);
            return playersDTO;
        }

        public async Task<PlayerDTO> GetPlayerById(int playerId)
        {
            var player = await unitOfWork.PlayerRepository.GetByIdAsync(playerId);
            var playerDTO = mapper.Map<PlayerDTO>(player);
            return playerDTO;
        }

        public async Task UpdatePlayer(int playerId, PlayerDTO playerDTO)
        {
            var player = mapper.Map<Player>(playerDTO);
            player.PlayerId = playerId;
            unitOfWork.PlayerRepository.Update(player);
            await unitOfWork.Commit();
        }

        public async Task<PlayerDTO> UpdatePartially(int playerId, JsonPatchDocument<PlayerDTO> playerDTODoc)
        {
            var player = await unitOfWork.PlayerRepository.GetByIdAsync(playerId);
            var playerDTO = mapper.Map<PlayerDTO>(player);
            playerDTODoc.ApplyTo(playerDTO);
            mapper.Map(playerDTO, player);
            unitOfWork.PlayerRepository.Update(player);
            await unitOfWork.Commit();
            return playerDTO;
        }

        public async Task<IEnumerable<PlayerDTO>> GetAllPlayers()
        {
            var players = await unitOfWork.PlayerRepository.GetPlayersWithDetails();
            var playersDTO = mapper.Map<IEnumerable<PlayerDTO>>(players);
            return playersDTO;
        }

        public async Task<IEnumerable<PlayerDTO>> GetAllPlayersByLastName(string LastName)
        {
            var players = await unitOfWork.PlayerRepository.GetPlayersWithDetails(x => x.LastName == LastName);
            var playersDTO = mapper.Map<IEnumerable<PlayerDTO>>(players);
            return playersDTO;
        }

        public async Task<IEnumerable<PlayerDTO>> GetAllPlayersByFirstName(string FirstName)
        {
            var players = await unitOfWork.PlayerRepository.GetPlayersWithDetails(x =>  x.FirstName == FirstName);
            var playersDTO = mapper.Map<IEnumerable<PlayerDTO>>(players);
            return playersDTO;
        }

        public async Task<IEnumerable<PlayerDTO>> GetAllPlayersByFirstNameAndLastName(string FirstName, string LastName)
        {
            var players = await unitOfWork.PlayerRepository.GetPlayersWithDetails(x => x.FirstName == FirstName && x.LastName == LastName);
            var playersDTO = mapper.Map<IEnumerable<PlayerDTO>>(players);
            return playersDTO;
        }
    }
}
