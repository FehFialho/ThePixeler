using Microsoft.AspNetCore.Mvc;
using ThePixeler.UseCases.GetPixels;
using ThePixeler.UseCases.PaintPixel;

namespace ThePixeler.EndPoints;
// ViewPixels
public static class PixelsEndPoints
{
    public static void PixelsEndpoints(this WebApplication app)
    {
        app.MapGet("pixels", async (
            [FromServices] GetPixelsUseCase useCase,
            [FromBody] GetPixelsPayload payload) =>
        {
            var result = await useCase.Do(payload);
            if (!result.IsSuccess)
                return Results.BadRequest();
            return Results.Ok(result.Data);
        }).RequireAuthorization();

        app.MapPost("paint-pixel", async (
            [FromServices] PaintPixelUseCase useCase,
            [FromBody] PaintPixelPayload payload) =>
        {
            var result = await useCase.Do(payload);
            if (!result.IsSuccess)
                return Results.BadRequest();
            return Results.Ok(result.Data);
        }).RequireAuthorization();
    }

}