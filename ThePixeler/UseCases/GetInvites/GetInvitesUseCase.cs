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
        // Procurar o usuário no banco e retornar as salas dele.
        var userGuid = extractJWTData.GetUserGuid(payload.HttpContext);
        var user = await ctx.Users.FindAsync(userGuid);
        
        if (user == null)
            return Result<GetInvitesResponse>.Fail("Usuário não encontrado");

        return Result<GetInvitesResponse>.Success(new(user.InvitesReceived));
    }
}