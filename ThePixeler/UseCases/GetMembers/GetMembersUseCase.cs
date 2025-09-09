using ThePixeler.Models;

namespace ThePixeler.UseCases.GetMembers;

public class GetMembersUseCase(ThePixelerDbContext ctx)
{
    public async Task<Result<GetMembersResponse>> Do(GetMembersPayload payload)
    {

        var room = await ctx.Rooms.FindAsync(payload.RoomID);
        var roomuser = room.RoomUsers;
        
        if (room == null)
            return Result<GetMembersResponse>.Fail("Sala não encontrada!");

        return Result<GetMembersResponse>.Success(new(roomuser));
    }
}