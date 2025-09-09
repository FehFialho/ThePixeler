using Microsoft.AspNetCore.Mvc;
using ThePixeler.UseCases.GetPlans;
using ThePixeler.UseCases.ValidateGiftCard;

namespace ThePixeler.EndPoints;
public static class PlansEndPoints
{
    public static void PlansEndpoints(this WebApplication app)
    {
        //Mostrar Palnos
        app.MapGet("plans", async (
            [FromServices] GetPlansUseCase useCase,
            [FromBody] GetPlansPayload payload) =>
        {
            var result = await useCase.Do(payload);
            if (!result.IsSuccess)
                return Results.BadRequest();
            return Results.Ok(result.Data);
        });

        //Validação de GiftCard
        app.MapPost("rescue-card", async (
            [FromServices] ValidateGiftCardUseCase useCase,
            [FromBody] ValidateGiftCardPayload payload) =>
        {
            var result = await useCase.Do(payload);
            if (!result.IsSuccess)
                return Results.BadRequest();
            return Results.Ok(result.Data);
        }).RequireAuthorization();
    }
}