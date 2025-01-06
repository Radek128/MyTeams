using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyTeam.Domain.Entities;

namespace MyTeam.Infrastructure.DAL.Configurations
{
    internal class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                   .HasConversion(x => x.Value, x => new(x));
            builder.Property(x => x.Name)
                   .HasConversion(x => x.Value, x => new(x));
            builder.HasMany(x => x.Members);
        }
    }
}
