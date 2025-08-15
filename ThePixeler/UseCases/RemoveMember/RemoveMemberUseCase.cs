namespace ThePixeler.UseCases.RemoveMember;

public class RemoveMemberUseCase
{
    public async Task<Result<RemoveMemberResponse>> Do(RemoveMemberPayload payload)
    {
        return Result<RemoveMemberResponse>.Success(null);
    }
}