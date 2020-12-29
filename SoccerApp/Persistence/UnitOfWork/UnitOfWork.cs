using Application.Interfaces.Persistence;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext context;
        private ICountryRepository countryRepository;
        private IGameRepository gameRepository;
        private ILeagueRepository leagueRepository;
        private IPlayerRepository playerRepository;
        private IStadiumRepository stadiumRepository;
        private ITeamRepository teamRepository;
        private IUserRepository userRepository;
        public ICountryRepository CountryRepository => countryRepository = countryRepository ?? new CountryRepository(context);
        public IGameRepository GameRepository => gameRepository = gameRepository ?? new GameRepository(context);
        public ILeagueRepository LeagueRepository => leagueRepository = leagueRepository ?? new LeagueRepository(context);
        public IPlayerRepository PlayerRepository => playerRepository = playerRepository ?? new PlayerRepository(context);
        public IStadiumRepository StadiumRepository => stadiumRepository = stadiumRepository ?? new StadiumRepository(context);
        public ITeamRepository TeamRepository => teamRepository = teamRepository ?? new TeamRepository(context);
        public IUserRepository UserRepository => userRepository = userRepository ?? new UserRepository(context);
        public UnitOfWork(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<int> Commit()
        {
            return await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
