using Microsoft.AspNetCore.Mvc;
using ThePixeler.UseCases.InviteMember;
using ThePixeler.UseCases.RespondInvite;
using ThePixeler.UseCases.GetInvites;
using ThePixeler.Services.ExtractJWTData;
using Microsoft.Extensions.Configuration.UserSecrets;
using ThePixeler.EndPoints.DTOs;

namespace ThePixeler.EndPoints;
// ViewInvites
public static class ViewInvitesEndPoints
{
    public static void ConfigureInviteEndpoints(this WebApplication app)
    {

        // Get de invites
        app.MapGet("invites", async (
            [FromServices] GetInvitesUseCase useCase,
            [FromServices] EFExtractJWTData extractJWTData,
            HttpContext context
        ) =>
        {
            var userID = await extractJWTData.GetUserGuid(context);
            if (userID is null)
                return Results.Unauthorized();

            var result = await useCase.Do(new (userID.Value)); // Exemplo de JWT Extract

            if (!result.IsSuccess)
                return Results.BadRequest();
            return Results.Ok(result.Data);

        }).RequireAuthorization();

        // Enviar Convite
        app.MapPost("send-invite", async (
            [FromServices] InviteMemberUseCase useCase,
            [FromServices] EFExtractJWTData extractJWTData,
            [FromBody] InviteMemberPayload payload,
            InviteEndpointDTO dto,
            HttpContext context
        ) => 
        {
            var senderID = await extractJWTData.GetUserGuid(context);
            if (senderID is null)
                return Results.Unauthorized();

            var result = await useCase.Do(payload);
            if (!result.IsSuccess)
                return Results.BadRequest();
            return Results.Ok(result.Data);
            
        }).RequireAuthorization();

        // Responder um Convite
        app.MapPost("respond-invite", async (
            [FromServices] RespondInviteUseCase useCase,
            [FromBody] RespondInvitePayload payload, HttpRequest request) =>
        {
            var result = await useCase.Do(payload);
            if (!result.IsSuccess)
                return Results.BadRequest();
            return Results.Ok(result.Data);
        }).RequireAuthorization();
    }
}
