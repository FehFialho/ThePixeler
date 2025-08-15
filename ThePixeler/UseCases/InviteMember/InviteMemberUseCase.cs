namespace ThePixeler.UseCases.InviteMember;

public class InviteMemberUseCase
{
    public async Task<Result<InviteMemberResponse>> Do(InviteMemberPayload payload)
    {
        return Result<InviteMemberResponse>.Success(null);
    }
}