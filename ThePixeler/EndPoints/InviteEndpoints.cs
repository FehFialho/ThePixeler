using Microsoft.AspNetCore.Mvc;
using ThePixeler.UseCases.InviteMember;
using ThePixeler.UseCases.RespondInvite;

namespace ThePixeler.EndPoints;
// ViewInvites
public static class ViewInvitesEndPoints
{
    public static void ConfigureInviteEndpoints(this WebApplication app)
    {
        app.MapGet("invites", (
        ) =>
        {
            // Pedir HTTP Request com o Token 
        }).RequireAuthorization();

        app.MapPost("send-invite", async (
            [FromServices] InviteMemberUseCase useCase,
            [FromBody] InviteMemberPayload payload) => 
        {
            var result = await useCase.Do(payload);
            if (!result.IsSuccess)
                return Results.BadRequest();
            return Results.Ok(result.Data);
        }).RequireAuthorization();

        app.MapPost("respond-invite", (
            [FromBody] RespondInvitePayload payload, HttpRequest request) =>
        {
            
            // Pegar JWT request.Headers.Authorization
        }).RequireAuthorization();
    }
}
