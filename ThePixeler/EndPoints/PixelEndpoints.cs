namespace ThePixeler.EndPoints;
// ViewPixels
public static class PixelsEndPoints
{
    public static void PixelsEndpoints(this WebApplication app)
    {
        app.MapGet("pixels/{roomId}", (int roomId) =>
        {

        }); //RequireAuthorization();

        app.MapPost("paint-pixel/{roomID}/{painterID}/{x}-{y}", (int roomID, int painterID, int x, int y) =>
        {

        }); //RequireAuthorization();
    }

}