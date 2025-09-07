using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PUBGAPI.Data;

namespace PUBGAPI.ModelsConfig;

public class GameConfig : IEntityTypeConfiguration<Game>
{
    public void Configure(EntityTypeBuilder<Game> builder)
    {
        builder.HasData(new Game
        {
            Id = 1,
            Name = "PUBG",
        });
    }
}