using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ThePixeler.EndPoints;
using ThePixeler.Models;
using ThePixeler.Services.ExtractJWTData;
using ThePixeler.Services.IPasswordServices;
using ThePixeler.Services.JWT;
using ThePixeler.Services.PBKDF2PasswordService;
using ThePixeler.Services.Profiles;
using ThePixeler.Services.Role;
using ThePixeler.UseCases.CreateProfile;
using ThePixeler.UseCases.CreateRoom;
using ThePixeler.UseCases.EditMember;
using ThePixeler.UseCases.EditProfileData;
using ThePixeler.UseCases.GetInvites;
using ThePixeler.UseCases.GetMembers;
using ThePixeler.UseCases.GetPixels;
using ThePixeler.UseCases.GetPlans;
using ThePixeler.UseCases.GetProfile;
using ThePixeler.UseCases.GetRoom;
using ThePixeler.UseCases.InviteMember;
using ThePixeler.UseCases.Login;
using ThePixeler.UseCases.PaintPixel;
using ThePixeler.UseCases.RemoveMember;
using ThePixeler.UseCases.RespondInvite;
using ThePixeler.UseCases.ValidateGiftCard;

var builder = WebApplication.CreateBuilder(args);

// Conectando com o banco de dados.
builder.Services.AddDbContext<ThePixelerDbContext>(options =>
{
    var sqlConn = Environment.GetEnvironmentVariable("SQL_CONNECTION");
    options.UseSqlServer(sqlConn);
});

// Configurar Serviços
builder.Services.AddTransient<IExtractJWTData, EFExtractJWTData>();
builder.Services.AddSingleton<IJWTService, JWTService>();
builder.Services.AddTransient<IPasswordService, PBKDF2PasswordService>();
builder.Services.AddTransient<IProfilesService, EFProfileService>();
//builder.Services.AddTransient<IRoleService, EFRoleService>();

//Configurar UseCases
builder.Services.AddTransient<CreateProfileUseCase>();
builder.Services.AddTransient<CreateRoomUseCase>();
builder.Services.AddTransient<EditMemberUseCase>();
builder.Services.AddTransient<EditProfileData>();
builder.Services.AddTransient<GetInvitesUseCase>();
builder.Services.AddTransient<GetMembersUseCase>();
builder.Services.AddTransient<GetPixelsUseCase>();
builder.Services.AddTransient<GetPlansUseCase>();
builder.Services.AddTransient<GetProfileUseCase>();
builder.Services.AddTransient<GetRoomUseCase>();
builder.Services.AddTransient<InviteMemberUseCase>();
builder.Services.AddTransient<LoginUseCase>();
builder.Services.AddTransient<PaintPixelUseCase>();
builder.Services.AddTransient<RemoveMemberUseCase>();
builder.Services.AddTransient<RespondInviteUseCase>();
builder.Services.AddTransient<ValidateGiftCardUseCase>();

// Autenticação JWT

var jwtSecret = Environment.GetEnvironmentVariable("JWT_SECRET");
var keyBytes = Encoding.UTF8.GetBytes(jwtSecret);
var key = new SymmetricSecurityKey(keyBytes);

// Começo MAIN Config JWT
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
    
// Fim MAIN Config JWT

// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(); // Config JWT
builder.Services.AddAuthorization(); // Config JWT

var app = builder.Build();

// app.UseSwagger();
// app.UseSwaggerUI();
app.ConfigureAuthEndpoints();
app.UseAuthentication(); // Config JWT
app.UseAuthorization(); // Config JWT


// Rodando!
app.Run();