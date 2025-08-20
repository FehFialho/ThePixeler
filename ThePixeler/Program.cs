using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ThePixeler.Models;

var builder = WebApplication.CreateBuilder(args);

// Conectando com o banco de dados.
builder.Services.AddDbContext<ThePixelerDbContext>(options =>
{
    var sqlConn = Environment.GetEnvironmentVariable("SQL_CONNECTION");
    options.UseSqlServer(sqlConn);
});

// Autenticação JWT

var jwtSecret = Environment.GetEnvironmentVariable("JWT_SECRET");
var keyBytes = Encoding.UTF8.GetBytes(jwtSecret);
var key = new SymmetricSecurityKey(keyBytes);

// Começo Config
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidIssuer = "ThePixeler", // Lembrar de Trocar o Nome
            ValidateIssuerSigningKey = true,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero,
            IssuerSigningKey = key,
        };
    });
// Fim Config


// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(); // Config
builder.Services.AddAuthorization(); // Config

var app = builder.Build();

// app.UseSwagger();
// app.UseSwaggerUI();

app.UseAuthentication(); // Config
app.UseAuthorization(); // Config


// Rodando!
app.Run();