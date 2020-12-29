using System;
using System.Collections.Generic;
using System.Text;
using Application.DTOs;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
namespace Application.Interfaces.Services
{
    public interface IStadiumService
    {
        
        Task<IEnumerable<StadiumDTO>> GetAllStadiums(string Name = null);
        Task<StadiumDTO> GetStadiumById(int stadiumId);
        Task AddStadium(StadiumDTO stadiumDTO);
        Task UpdateStadium(int stadiumId, StadiumDTO stadiumDTO);
        Task DeleteAllStadiums();
        Task DeleteStadiumById(int stadiumId);
        Task<StadiumDTO> UpdatePartially(int stadiumId, JsonPatchDocument<StadiumDTO> stadiumDTO);
    }
}
