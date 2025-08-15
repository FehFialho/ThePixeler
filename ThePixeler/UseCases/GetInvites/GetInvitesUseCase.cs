namespace ThePixeler.UseCases.GetInvites;

public class GetInvitesUseCase
{
    public async Task<Result<GetInvitesResponse>> Do(GetInvitesPayload payload)
    {
        return Result<GetInvitesResponse>.Success(null);
    }
}