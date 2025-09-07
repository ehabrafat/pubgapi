using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PUBGAPI.Data;

namespace PUBGAPI.ModelsConfig;

public class GameModeConfig : IEntityTypeConfiguration<GameMode>
{
    public void Configure(EntityTypeBuilder<GameMode> builder)
    {
        builder.HasData(
            new GameMode { Id = 1, Name = "Solo FPP", Description = "First-person solo", GameId = 1 },
            new GameMode { Id = 2, Name = "Duo FPP", Description = "First-person duo", GameId = 1 },
            new GameMode { Id = 3, Name = "Squad FPP", Description = "First-person squad (4 players)", GameId = 1 },
            new GameMode { Id = 4, Name = "Solo", Description = "Third-person solo", GameId = 1 },
            new GameMode { Id = 5, Name = "Duo", Description = "Third-person duo", GameId = 1 },
            new GameMode { Id = 6, Name = "Squad", Description = "Third-person squad (4 players)", GameId = 1 }
            );
    }
}