using System;
using System.Collections.Generic;
using System.Text;
using Application.Interfaces.Persistence;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace Persistence.Repositories
{
    public class CountryRepository:Repository<CCountry>,ICountryRepository
    {
        public ApplicationDbContext Context
        {
            get { return context; }
        }

        public DbSet<CCountry> dbSet { get; }

        public CountryRepository(ApplicationDbContext context) : base(context) { dbSet = context.Set<CCountry>(); }
    }
}
