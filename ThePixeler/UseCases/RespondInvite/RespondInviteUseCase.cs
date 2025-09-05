using ThePixeler.Models;
using ThePixeler.Services.ExtractJWTData;

namespace ThePixeler.UseCases.RespondInvite;

public class RespondInviteUseCase (
    EFExtractJWTData extractJWTData,
    ThePixelerDbContext ctx
    )
{
    public async Task<Result<RespondInviteResponse>> Do(RespondInvitePayload payload)
    {
        var invite = await ctx.Invites.FindAsync(payload.inviteId);
        var room = await ctx.Rooms.FindAsync(payload.roomID);
        var receiver = await ctx.Users.FindAsync(payload.userID); //usar extract
        var sender = invite.Sender;

        if (payload.response)
            receiver.Rooms.Add(room);

        receiver.InvitesReceived.Remove(invite);
        sender.InvitesSended.Remove(invite);

        return Result<RespondInviteResponse>.Success(null);
    }
}