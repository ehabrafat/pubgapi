using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PUBGAPI.Data;

namespace PUBGAPI.ModelsConfig;

public class TournamentConfig : IEntityTypeConfiguration<Tournament>
{
    public void Configure(EntityTypeBuilder<Tournament> builder)
    {
        builder.HasData(new Tournament
        {
            Id = 1,
            Name = "Rambo",
            PrizePool = 12,
            Players = 5,
            Ticket = 3,
            GameModeId = 1
        });
        builder.HasData(new Tournament
        {
            Id = 2,
            Name = "Ice",
            PrizePool = 20,
            Players = 7,
            Ticket = 4,
            GameModeId = 2
        });
    }
}