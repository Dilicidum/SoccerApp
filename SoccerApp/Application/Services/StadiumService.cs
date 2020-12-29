using Application.DTOs;
using Application.Interfaces.Persistence;
using Application.Interfaces.Services;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
namespace Application.Services
{
    public class StadiumService : IStadiumService
    {
        private IUnitOfWork unitOfWork;
        private IMapper mapper;
        public StadiumService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task AddStadium(StadiumDTO stadiumDTO)
        {
            var stadium = mapper.Map<Stadium>(stadiumDTO);
            await unitOfWork.StadiumRepository.AddAsync(stadium);
            await unitOfWork.Commit();
        }

        public async Task DeleteAllStadiums()
        {
            var teams = await unitOfWork.TeamRepository.GetAllAsync();
            unitOfWork.TeamRepository.RemoveRange(teams);
            await unitOfWork.Commit();
        }

        public async Task DeleteStadiumById(int stadiumId)
        {
            var stadium = await unitOfWork.StadiumRepository.GetByIdAsync(stadiumId);
            unitOfWork.StadiumRepository.Remove(stadium);
            await unitOfWork.Commit();
        }

        public async Task<IEnumerable<StadiumDTO>> GetAllStadiums(string Name = null)
        {
            var stadiums = await unitOfWork.StadiumRepository.GetAsync(stadium => stadium.Name == Name);
            var stadiumsDTO = mapper.Map<IEnumerable<StadiumDTO>>(stadiums);
            return stadiumsDTO;
        }

        public async Task<StadiumDTO> GetStadiumById(int stadiumId)
        {
            var stadium = await unitOfWork.StadiumRepository.GetStadiumByIdWithDetails(stadiumId);
            var stadiumDTO = mapper.Map<StadiumDTO>(stadium);
            return stadiumDTO;
        }

        public async Task UpdateStadium(int stadiumId, StadiumDTO stadiumDTO)
        {
            var stadium = mapper.Map<Stadium>(stadiumDTO);
            unitOfWork.StadiumRepository.Update(stadium);
            await unitOfWork.Commit();
        }

        public async Task<StadiumDTO> UpdatePartially(int StadiumId, JsonPatchDocument<StadiumDTO> StadiumDTODoc)
        {
            var Stadium = await unitOfWork.StadiumRepository.GetByIdAsync(StadiumId);
            var StadiumDTO = mapper.Map<StadiumDTO>(Stadium);
            StadiumDTODoc.ApplyTo(StadiumDTO);
            mapper.Map(StadiumDTO, Stadium);
            unitOfWork.StadiumRepository.Update(Stadium);
            await unitOfWork.Commit();
            return StadiumDTO;
        }
    }
}
