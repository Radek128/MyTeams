using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySpot.Application.Abstractions;
using MyTeam.Application.Abstractions;
using MyTeam.Application.Commands;
using MyTeam.Application.Commands.Handlers;
using MyTeam.Application.Dto;
using MyTeam.Application.Queries;
using MyTeam.Application.Queries.Handlers;
using MyTeam.Domain.Repositories;
using MyTeam.Infrastructure.Configurations;
using MyTeam.Infrastructure.DAL;
using MyTeam.Infrastructure.DAL.Repositores;
using MyTeam.Infrastructure.FileStorage;

namespace MyTeam.Infrastructure.Extensions
{
    public static class Bootstrapper
    {
        private const string OptionsSectionName = "postgres";

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IFileService, LocalStorageFileService>();

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IMemberRepository, MemberRepository>();
            services.AddScoped<ITeamRepository, TeamRepository>();

            return services;
        }

        public static IServiceCollection AddCommands(this IServiceCollection services)
        {
            services.AddScoped<ICommandHandler<CreateNewMember>, CreateNewMemberHandler>();
            services.AddScoped<ICommandHandler<CreateNewTeam>, CreateNewTeamHandler>();
            services.AddScoped<ICommandHandler<UpdateMember>, UpdateMemberHandler>();

            return services;
        }

        public static IServiceCollection AddQueries(this IServiceCollection services)
        {
            services.AddScoped<IQueryHandler<GetMember, MemberDto>, GetMemberQueryHandler>();
            services.AddScoped<IQueryHandler<GetMembers, IEnumerable<MemberDto>>, GetMembersQueryHandler>();

            return services;
        }

        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<Postgres>(x => { });
            var postgresOptions = configuration.GetOptions<Postgres>(OptionsSectionName);
            services.AddDbContext<TeamDbContext>(x => x.UseNpgsql(postgresOptions.ConnectionString));
            return services;
        }

        private static T GetOptions<T>(this IConfiguration configuration, string sectionName) where T : class, new()
        {
            var options = new T();
            var section = configuration.GetRequiredSection(sectionName);
            section.Bind(options);

            return options;
        }
    }
}
