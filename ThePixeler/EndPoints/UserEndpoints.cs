using Microsoft.AspNetCore.Mvc;
using ThePixeler.UseCases.CreateProfile;
using ThePixeler.UseCases.EditProfileData;
using ThePixeler.UseCases.GetProfile;
using ThePixeler.UseCases.Login;

namespace ThePixeler.EndPoints;
// Auth
public static class AuthEndPoints
{
    public static void ConfigureAuthEndpoints(this WebApplication app)
    {
        // Auntenticação
        app.MapPost("auth", async (
            [FromBody] LoginPayload payload,
            [FromServices]LoginUseCase useCase) =>
        {   
            var result = await useCase.Do(payload);
            if (!result.IsSuccess)
                return Results.BadRequest();
            return Results.Ok(result.Data);
        });

        //mudar aqui e o useCase / Mudar as Informações
        app.MapPost("change-info", async (
            [FromServices] EditProfileData useCase,
            [FromBody] EditProfileDataPayload payload) =>
        {
            var result = await useCase.Do(payload);

            if (!result.IsSuccess)
                return Results.BadRequest();
            return Results.Ok(result.Data);

        }).RequireAuthorization();

        //Visualizar Perfil
        app.MapGet("view-profile", async (
            [FromServices] GetProfileUseCase useCase,
            [FromBody] GetProfilePayload payload) =>
        {
            var result = await useCase.Do(payload);

            if (!result.IsSuccess)
                return Results.BadRequest();
            return Results.Ok(result.Data);
        });
        
        //Crear um novo usuario
        app.MapPost("createUser", async (
            [FromServices] CreateProfileUseCase useCase,
            [FromBody] CreateProfilePayload payload) =>
        {
            var result = await useCase.Do(payload);

            if (!result.IsSuccess)
                return Results.BadRequest();
            return Results.Ok(result.Data);
        }); 
    }
}