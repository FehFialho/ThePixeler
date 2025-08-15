using Microsoft.EntityFrameworkCore;
using ThePixeler.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ThePixelerDbContext>(options =>
{
    var sqlConn = Environment.GetEnvironmentVariable("SQL_CONNECTION");
    options.UseSqlServer(sqlConn);
});

var app = builder.Build();

app.MapGet("/oi", () => "Hello World 2");

app.MapGet("/", () => "Hello World!");

Console.WriteLine("Hello World");
app.Run();
