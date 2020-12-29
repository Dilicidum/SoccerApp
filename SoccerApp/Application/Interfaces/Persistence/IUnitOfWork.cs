using Application.Interfaces.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Persistence
{
    public interface IUnitOfWork
    {
        ICountryRepository CountryRepository { get;}
        IGameRepository GameRepository { get; }
        ILeagueRepository LeagueRepository { get; }
        IPlayerRepository PlayerRepository { get;}
        IStadiumRepository StadiumRepository { get;  }
        ITeamRepository TeamRepository { get; }
        IUserRepository UserRepository { get; }
        Task<int> Commit();
    }

}
