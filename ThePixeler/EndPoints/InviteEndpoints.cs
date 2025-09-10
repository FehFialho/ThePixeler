using Microsoft.AspNetCore.Mvc;
using ThePixeler.UseCases.InviteMember;
using ThePixeler.UseCases.RespondInvite;
using ThePixeler.UseCases.GetInvites;
using ThePixeler.Services.ExtractJWTData;
using Microsoft.Extensions.Configuration.UserSecrets;
using ThePixeler.EndPoints.DTOs;
using ThePixeler.Models;

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

        // Enviar Convite ( Aqui Exemplo com DTO e JWT Extract! )
        app.MapPost("send-invite", async (
            [FromServices] InviteMemberUseCase useCase,
            [FromServices] EFExtractJWTData extractJWTData,
            [FromBody] InviteMemberPayload payload,
            HttpContext context // Não esquecer do Context para poder tirar o JWT
        ) => 
        { 
            
            // Extração e Verificação do JWT
            var senderID = await extractJWTData.GetUserGuid(context); 

            if (senderID is null)
                return Results.Unauthorized();

            // Junção do Payload do Front + Informações do JWT
            var dto = new InviteMemberDTO(
                senderID.Value,
                payload.ReceiverID,
                payload.RoomID
            );

            // Enviar o DTO para o UseCase + Resposta
            var result = await useCase.Do(dto);
            if (!result.IsSuccess)
                return Results.BadRequest();
            return Results.Ok(result.Data);

        }).RequireAuthorization();

        // Responder um Convite
        app.MapPost("respond-invite", async (
            [FromServices] RespondInviteUseCase useCase,
            [FromServices] EFExtractJWTData extractJWTData,
            [FromBody] RespondInvitePayload payload, HttpRequest request,
            HttpContext context
        ) =>
        {
            // Extração e Verificação do JWT
            var JwtUserID = await extractJWTData.GetUserGuid(context); 

            if (JwtUserID is null)
                return Results.Unauthorized();

            // DTO
            var dto = new RespondInviteDTO(
                userID = JwtUserID,
                inviteId = payload.inviteId,
                response = payload.response,
                roomID = payload.roomID
            );

            var result = await useCase.Do(dto);
            if (!result.IsSuccess)
                return Results.BadRequest();
            return Results.Ok(result.Data);
            
        }).RequireAuthorization();
    }
}
