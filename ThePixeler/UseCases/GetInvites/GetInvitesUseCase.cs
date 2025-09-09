using ThePixeler.Models;
using ThePixeler.Services.ExtractJWTData;

namespace ThePixeler.UseCases.GetInvites;

public class GetInvitesUseCase(
    IExtractJWTData extractJWTData,
    ThePixelerDbContext ctx
)
{
    public async Task<Result<GetInvitesResponse>> Do(GetInvitesPayload payload)
    {        
        return Result<GetInvitesResponse>.Success(null);
    }
}