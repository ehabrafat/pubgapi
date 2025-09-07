using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PUBGAPI.Data;

namespace PUBGAPI.ModelsConfig;

public class GameModeConfig : IEntityTypeConfiguration<GameMode>
{
    public void Configure(EntityTypeBuilder<GameMode> builder)
    {
        builder.HasData(
            new GameMode { Id = 1, Name = "solo-fpp", Description = "First-person solo", GameId = 1 },
            new GameMode { Id = 2, Name = "duo-fpp", Description = "First-person duo", GameId = 1 },
            new GameMode { Id = 3, Name = "squad-fpp", Description = "First-person squad (4 players)", GameId = 1 },
            new GameMode { Id = 4, Name = "solo", Description = "Third-person solo", GameId = 1 },
            new GameMode { Id = 5, Name = "duo", Description = "Third-person duo", GameId = 1 },
            new GameMode { Id = 6, Name = "squad", Description = "Third-person squad (4 players)", GameId = 1 });
    }
}