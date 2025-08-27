using ThePixeler.Models;

namespace ThePixeler.UseCases.GetRoom;

public class GetRoomUseCase(ThePixelerDbContext ctx)
{
    public async Task<Result<GetRoomResponse>> Do(GetRoomPayload payload)
    {
        var user = await ctx.Users.FindAsync(payload.User);

        var rooms = user.Rooms;

        return Result<GetRoomResponse>.Success();
    }
}