using Microsoft.AspNetCore.Mvc;
using ThePixeler.UseCases.CreateRoom;
using ThePixeler.UseCases.GetMembers;

namespace ThePixeler.EndPoints;
// CreateRoom
public static class CreateRoomEndPoints
{
    public static void ConfigureRoomEndpoints(this WebApplication app)
    {
        app.MapPost("create-room", async (
            [FromServices] CreateRoomUseCase useCase,
            [FromBody] CreateRoomPayload payload) =>
        {
            var result = await useCase.Do(payload);

            if (!result.IsSuccess)
                return Results.BadRequest();
            return Results.Ok(result.Data);
            
        }).RequireAuthorization();

        // ViewRooms
        app.MapGet("rooms/", async () =>
        {

        }).RequireAuthorization();

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