using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PUBGAPI.Data;

namespace PUBGAPI.ModelsConfig;

public class GameAccountConfig : IEntityTypeConfiguration<GameAccount>
{
    public void Configure(EntityTypeBuilder<GameAccount> builder)
    {
        builder.HasOne(x => x.ConnectedGame)
            .WithOne(x => x.Account)
            .HasForeignKey<GameAccount>(x => x.ConnectedGameId)
            .OnDelete(DeleteBehavior.ClientSetNull);
    }
}