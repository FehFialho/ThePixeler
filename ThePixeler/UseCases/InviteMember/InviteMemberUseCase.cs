using ThePixeler.Models;

namespace ThePixeler.UseCases.InviteMember;

public class InviteMemberUseCase( ThePixelerDbContext ctx )
{
    public async Task<Result<InviteMemberResponse>> Do(InviteMemberPayload payload)
    {

        var invite = new Invite
        {
            RoomID = payload.RoomID,
            ReceiverID = payload.ReceiverID,
            SenderID = payload.SenderID
        };

        // O invite vai automaticamente para a lista de invites do Receiver?
        ctx.Invites.Add(invite);
        await ctx.SaveChangesAsync();

        return Result<InviteMemberResponse>.Success(new());
    }
}