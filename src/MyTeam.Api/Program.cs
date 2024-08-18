using Microsoft.EntityFrameworkCore;
using MyTeam.Infrastructure.DAL;
using MyTeam.Infrastructure.Extensions;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()
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
    .AddQueries();

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<TeamDbContext>();
    await dbContext.Database.MigrateAsync();
}
app.UseCors("AllowAll");
app.UseRouting();
app.UseStaticFiles();
app.MapControllers();
app.Run();


