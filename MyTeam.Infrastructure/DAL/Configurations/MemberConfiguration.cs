using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyTeam.Domain.Entities;

namespace MyTeam.Infrastructure.DAL.Configurations
{
    internal class MemberConfiguration : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                   .HasConversion(x => x.Value, x => new(x));
            builder.Property(x => x.TeamId)
                   .HasConversion(x => x.Value, x => new(x));
            builder.Property(x => x.IsActive);
            builder.Property(x => x.FullName)
                   .HasConversion(x => x.Value, x => new(x));
            builder.Property(x => x.Name)
                   .HasConversion(x => x.Value, x => new(x));
            builder.Property(x => x.PhoneNumber)
                   .HasConversion(x => x.Value, x => new(x));
            builder.Property(x => x.Email)
                   .HasConversion(x => x.Value, x => new(x));
            builder.Property(x => x.Avatar)
                   .HasConversion(x => x.Path, x => new(x));
            builder.Property(x => x.CreatedOn);
        }
    }
}
