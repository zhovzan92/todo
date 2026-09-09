using Infrastructure.Postgres.Scaffolding;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddDbContext<MyDbContext>(conf=>
{
    conf.UseNpgsql(Environment.GetEnvironmentVariable("MyConnectionString"));
});


var app = builder.Build();
app.MapGet("/", ([FromServices] MyDbContext dbContext) =>
{
    var objects = dbContext.Todos.ToList(); // the way to take all the rows in the todotable. It knows abot todo entity
});
app.Run();
