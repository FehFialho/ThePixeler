using ThePixeler.Models;

namespace ThePixeler.UseCases.InviteMember;

public class InviteMemberUseCase( ThePixelerDbContext ctx )
{
    public async Task<Result<InviteMemberResponse>> Do(InviteMemberDTO  dto)//nao esquecer de arrumar aqui para invitememberDTo
    {

        var invite = new Invite
        {
            RoomID = dto.RoomID,
            ReceiverID = dto.ReceiverID,
            SenderID = dto.SenderID
        };

        ctx.Invites.Add(invite);
        await ctx.SaveChangesAsync();

        return Result<InviteMemberResponse>.Success(new());
    }
}