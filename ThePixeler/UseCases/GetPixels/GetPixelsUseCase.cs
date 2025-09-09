using Microsoft.EntityFrameworkCore;
using ThePixeler.Models;

namespace ThePixeler.UseCases.GetPixels;

public class GetPixelsUseCase(ThePixelerDbContext ctx)
{
    public async Task<Result<GetPixelsResponse>> Do(GetPixelsPayload payload)
    {

        var pixels = await ctx.Pixels.Where(p => p.RoomID == payload.RoomID).ToListAsync();
        
        if (pixels == null)
            return Result<GetPixelsResponse>.Fail("Sala não encontrada!");

        return Result<GetPixelsResponse>.Success(new(pixels));
    }
}