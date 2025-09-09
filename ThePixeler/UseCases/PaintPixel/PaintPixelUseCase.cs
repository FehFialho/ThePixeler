using Microsoft.Identity.Client;
using ThePixeler.Models;
using ThePixeler.Services.Role;

namespace ThePixeler.UseCases.PaintPixel;

public class PaintPixelUseCase(
    ThePixelerDbContext ctx,
    IRoleService roleService
)
{
    public async Task<Result<PaintPixelResponse>> Do(PaintPixelPayload payload)
    {
        var roomuser = await ctx.RoomUsers.FindAsync(payload.PainterID);

        var role = await roleService.GetRole(roomuser.RoleID);

        if (role == RoomRole.Plateia)
            return Result<PaintPixelResponse>.Fail("Usuário sem permissão!");
        
        var pixel = new Pixel
        {
            xPosition = payload.x,
            yPosition = payload.y,
            RoomID = payload.roomID,
            UserID = payload.PainterID,
            R = payload.R,
            G = payload.G,
            B = payload.B
        };

        ctx.Pixels.Add(pixel);
        await ctx.SaveChangesAsync();
  
        return Result<PaintPixelResponse>.Success(new());
    }
}