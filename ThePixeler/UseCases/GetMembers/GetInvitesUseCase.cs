namespace ThePixeler.UseCases.GetMembers;

public class GetMembersUseCase
{
    public async Task<Result<GetMembersResponse>> Do(GetMembersPayload payload)
    {
        return Result<GetMembersResponse>.Success(null);
    }
}