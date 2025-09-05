using Microsoft.AspNetCore.Mvc;
using ThePixeler.UseCases.CreateRoom;
using ThePixeler.UseCases.GetMembers;
using ThePixeler.UseCases.GetRoom;

namespace ThePixeler.EndPoints;
// CreateRoom
public static class CreateRoomEndPoints
{
    public static void ConfigureRoomEndpoints(this WebApplication app)
    {
        //Criar Sala
        app.MapPost("create-room", async (
            [FromServices] CreateRoomUseCase useCase,
            [FromBody] CreateRoomPayload payload) =>
        {
            var result = await useCase.Do(payload);

            if (!result.IsSuccess)
                return Results.BadRequest();
            return Results.Ok(result.Data);
            
        }).RequireAuthorization();

        // Visualizar salas
        app.MapGet("rooms/", async (
            [FromServices] GetRoomUseCase useCase,
            [FromBody] GetRoomPayload payload
        ) =>
        {
            var result = await useCase.Do(payload);

            if (!result.IsSuccess)
                return Results.BadRequest();
            return Results.Ok(result.Data);

        }).RequireAuthorization();

        //Mostrar Membros da sala
        app.MapGet("members", async (
            [FromServices] GetMembersUseCase useCase,
            [FromBody] GetMembersPayload payload) => 
        {
             var result = await useCase.Do(payload);

            if (!result.IsSuccess)
                return Results.BadRequest();
            return Results.Ok(result.Data);
        }).RequireAuthorization();
    }
}