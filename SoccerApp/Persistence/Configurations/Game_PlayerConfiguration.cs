using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;
namespace Persistence.Configurations
{
    public class Game_PlayerConfiguration : IEntityTypeConfiguration<Game_Player>
    {
        public void Configure(EntityTypeBuilder<Game_Player> builder)
        {
            
        }
    }
}
