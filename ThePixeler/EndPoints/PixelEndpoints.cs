namespace ThePixeler.EndPoints;
// ViewPixels
public static class ViewPixelsEndPoints
{
    public static void ConfigureViewPixelsEndpoints(this WebApplication app)
    {
        app.MapGet("pixels/{roomId}", (int roomId) => 
        {

        }); //RequireAuthorization();
    }
}
// PaintPixel
public static class PaintPixelEndPoints
{
    public static void ConfigurePaintPixelEndpoints(this WebApplication app)
    {
        app.MapPost("paint-pixel/{roomID}/{painterID}/{x}-{y}", (int roomID, int painterID ,int x, int y) => 
        {

        }); //RequireAuthorization();
    }
}