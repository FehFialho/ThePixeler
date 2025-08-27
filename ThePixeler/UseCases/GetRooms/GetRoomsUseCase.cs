using ThePixeler.Models;

namespace ThePixeler.UseCases.GetRoom;

public class GetRoomUseCase(ThePixelerDbContext ctx)
{
    public async Task<Result<GetRoomResponse>> Do(GetRoomPayload payload)
    {
        var user = await ctx.Users.FindAsync(payload.UserID);

        var rooms = user.Rooms;

        if (user == null)
            return Result<GetRoomResponse>.Fail("Usuário não encontrado");

        return Result<GetRoomResponse>.Success(new (rooms));
    }
}