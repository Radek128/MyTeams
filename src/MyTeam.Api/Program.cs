using Microsoft.EntityFrameworkCore;
using MyTeam.Infrastructure.DAL;
using MyTeam.Infrastructure.Exceptions;
using MyTeam.Infrastructure.Extensions;
using MyTeam.Infrastructure.WebHooks;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.WithOrigins("http://localhost:3000")
            .AllowCredentials()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

builder.Services.AddControllers();
builder.Services
    .AddDatabase(builder.Configuration)
    .AddRepositories()
    .AddServices()
    .AddCommands()
    .AddQueries()
    .AddHelpers();

builder.Services.AddSignalR();
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<TeamDbContext>();
    await dbContext.Database.MigrateAsync();
}
app.UseCors("AllowAll");
app.UseMiddleware<ExceptionMiddleware>();
app.MapHub<TeamHub>("/newTeamMember");
app.UseRouting();
app.UseStaticFiles();
app.MapControllers();
app.Run();


