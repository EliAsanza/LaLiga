using LaLiga.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LaLiga.Infraestructure.Configurations
{
    public class MatchesConfigurations : IEntityTypeConfiguration<Matches>
    {
        public void Configure(EntityTypeBuilder<Matches> builder)
        {
            builder.ToTable("matches")
                .HasKey(x => x.MatchesId);

            builder.Property(p => p.MatchesId)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(t => t.MatchDate)
                .IsRequired();

            builder.Property(t => t.LocalTeamId)
                .IsRequired();

            builder.Property(t => t.VisitorTeamId)
                .IsRequired();

            builder.Property(t => t.LocalScore)
                .IsRequired();

            builder.Property(t => t.VisitorScore)
                .IsRequired();
        }
    }
}
