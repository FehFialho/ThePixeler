namespace ThePixeler.UseCases.RespondInvite;

public class RespondInviteUseCase
{
    public async Task<Result<RespondInviteResponse>> Do(RespondInvitePayload payload)
    {
        return Result<RespondInviteResponse>.Success(null);
    }
}