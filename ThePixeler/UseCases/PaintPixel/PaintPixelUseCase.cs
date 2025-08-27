using ThePixeler.Models;

namespace ThePixeler.UseCases.PaintPixel;

public class PaintPixelUseCase(ThePixelerDbContext ctx)
{
    public async Task<Result<PaintPixelResponse>> Do(PaintPixelPayload payload)
    {

        var room = await ctx.Rooms.FindAsync(payload.roomID);
        var user = await ctx.Users.FindAsync(payload.PainterID);

        var pixel = new Pixel
        {
            xPosition = payload.x,
            yPosition = payload.y,
            Room = room,
            RoomID = payload.roomID,
            User = user,
            UserID = payload.PainterID
        };
        
        // int x,
        // int y,
        // Color color,
        // Guid PainterID,
        // Guid roomID
        return Result<PaintPixelResponse>.Success(null);
    }
}