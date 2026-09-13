using api.Etc;
using Infrastructure.Postgres.Scaffolding;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


var appOptions = builder.Services.AddAppOptions(
   builder.Configuration
);
builder.Services.AddDbContext<MyDbContext>(conf=>
{
    conf.UseNpgsql(appOptions.DbConnectionString);
});


var app = builder.Build();
app.MapGet("/", ([FromServices] MyDbContext dbContext) =>
{
    var objects = dbContext.Todos.ToList(); // the way to take all the rows in the todotable. It knows abot todo entity
});
app.Run();
