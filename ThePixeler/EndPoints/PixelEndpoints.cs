using Microsoft.AspNetCore.Mvc;
using ThePixeler.UseCases.GetPixels;
using ThePixeler.UseCases.PaintPixel;

namespace ThePixeler.EndPoints;
// ViewPixels
public static class PixelsEndPoints
{
    public static void PixelsEndpoints(this WebApplication app)
    {
        app.MapGet("pixels", ([FromBody]GetPixelsPayload payload) =>
        {
            // Get 
        }).RequireAuthorization();

        app.MapPost("paint-pixel", ([FromBody]PaintPixelPayload payload) =>
        {

        }).RequireAuthorization();
    }

}