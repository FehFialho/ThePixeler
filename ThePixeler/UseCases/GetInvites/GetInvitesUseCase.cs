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
        var invites = await ctx.Invites.Where(p => p.userID == payload.UserId).ToListAsync();
        
        if (invites == null)
            return Result<GetPixelsResponse>.Fail("Usuário não encontrado!");

        return Result<GetPixelsResponse>.Success(new(invites));
    }
}