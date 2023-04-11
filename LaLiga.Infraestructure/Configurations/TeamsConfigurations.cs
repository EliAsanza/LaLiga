using LaLiga.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LaLiga.Infraestructure.Configurations
{
    internal class TeamsConfigurations : IEntityTypeConfiguration<Teams>
    {
        public void Configure(EntityTypeBuilder<Teams> builder)
        {
            builder.ToTable("teams")
                .HasKey(x => x.TeamsId);

            builder.Property(p => p.TeamsId)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(t => t.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(t => t.Color)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(t => t.CreatedDate)
                .IsRequired();
        }
    }
}