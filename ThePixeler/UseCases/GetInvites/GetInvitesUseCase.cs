using ThePixeler.Services.ExtractJWTData;

namespace ThePixeler.UseCases.GetInvites;

public class GetInvitesUseCase(
    IExtractJWTData extractJWTData
)
{
    public async Task<Result<GetInvitesResponse>> Do(GetInvitesPayload payload)
    {
        // precisa mesmo do payload?
        var userGuid = extractJWTData.GetUserGuid;

        // Procurar o usuário no banco e retornar as salas dele.

        return Result<GetInvitesResponse>.Success(null);
    }
}