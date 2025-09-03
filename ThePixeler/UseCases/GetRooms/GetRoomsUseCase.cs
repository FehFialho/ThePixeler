using ThePixeler.Models;

namespace ThePixeler.UseCases.GetRoom;

public class GetRoomUseCase(ThePixelerDbContext ctx)
{
    public async Task<Result<GetRoomResponse>> Do(GetRoomPayload payload)
    {
        var user = await ctx.Users.FindAsync(payload.UserID);
        if (user == null)
            return Result<GetRoomResponse>.Fail("Usuário não encontrado");

        var rooms = user.Rooms;

        return Result<GetRoomResponse>.Success(new (rooms));
    }
}