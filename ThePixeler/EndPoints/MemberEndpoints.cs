namespace ThePixeler.EndPoints;

using Microsoft.AspNetCore.Mvc;
using ThePixeler.UseCases.EditMember;
using ThePixeler.UseCases.RemoveMember;

// EditMember
public static class MemberEndPoints
{
    public static void MemberEndpoints(this WebApplication app)
    {
        // Editar Membro
        app.MapPut("edit-member/{userGuid}", async (
            [FromServices] EditMemberUseCase useCase,
            [FromBody] EditMemberPayload payload
        ) =>
        {
            var result = await useCase.Do(payload);
            if (!result.IsSuccess)
                return Results.BadRequest();
            return Results.Ok(result.Data);
        }).RequireAuthorization();

        // Remover Membros
        app.MapDelete("remove-member/{userGuid}", async(
            [FromServices] RemoveMemberUseCase useCase,
            [FromBody] RemoveMemberPayload payload
        ) =>
        {
            var result = await useCase.Do(payload);
            if (!result.IsSuccess)
                return Results.BadRequest();
            return Results.Ok(result.Data);
        }).RequireAuthorization();

    }
}
