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

        // <-- Get de invites -->
        app.MapGet("invites", async (
            [FromServices] GetInvitesUseCase useCase,
            [FromServices] EFExtractJWTData extractJWTData,
            HttpContext context
        ) =>
        
        {
            // Extract JWT
            var userID = await extractJWTData.GetUserGuid(context);
            if (userID is null)
                return Results.Unauthorized();

            var dto = new GetInvitesDTO(userID.Value); // Mandando o DTO sozinho já que só precisa do UserID
            var result = await useCase.Do(dto);
            
            if (!result.IsSuccess)
                return Results.BadRequest(result.Reason);

            return Results.Ok(result.Data);

        }).RequireAuthorization();

        // <-- Enviar Convite -->
        // ( Aqui Exemplo com DTO e JWT Extract! )
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

        // <--Responder um Convite-->
        app.MapPost("respond-invite", async (
            [FromServices] RespondInviteUseCase useCase,
            [FromServices] EFExtractJWTData extractJWTData,
            [FromBody] RespondInvitePayload payload, HttpRequest request,
            HttpContext context
        ) =>
        {
            // Extração e Verificação do JWT
            var dtoUserID = await extractJWTData.GetUserGuid(context); 

            if (dtoUserID is null)
                return Results.Unauthorized();

            // Cria DTO juntando Infos
            var dto = new RespondInviteDTO(
                dtoUserID.Value,
                payload.inviteId,
                payload.response,
                payload.roomID
            );

            var result = await useCase.Do(dto);
            if (!result.IsSuccess)
                return Results.BadRequest();
            return Results.Ok(result.Data);

        }).RequireAuthorization();
    }
}
