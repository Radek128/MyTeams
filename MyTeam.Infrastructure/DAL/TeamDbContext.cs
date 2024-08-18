using Microsoft.EntityFrameworkCore;
using MyTeam.Domain.Entities;

namespace MyTeam.Infrastructure.DAL
{
    public class TeamDbContext : DbContext
    {
        public DbSet<Team> Teams { get; set; }
        public DbSet<Member> Members { get; set; }
        public TeamDbContext(DbContextOptions<TeamDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
