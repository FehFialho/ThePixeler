using ThePixeler.EndPoints.DTOs;
using ThePixeler.Models;
using ThePixeler.Services.ExtractJWTData;

namespace ThePixeler.UseCases.GetInvites;

public class GetInvitesUseCase(

    // private readonly IExtractJWTData extractJWTData;
    // private readonly ThePixelerDbContext ctx;

    // public GetInvitesUseCase(IExtractJWTData extractJWTData, ThePixelerDbContext ctx)
    // {
    //     this.extractJWTData = extractJWTData;
    //     this.ctx = ctx;
    // }
    
    IExtractJWTData extractJWTData,
    ThePixelerDbContext ctx
)
{
    public async Task<Result<GetInvitesResponse>> Do(GetInvitesDTO dto)
    {    
        var invites = await ctx.Invites.Where(p => p.userID == dto.UserId).ToListAsync();

        if (!invites.Any())
            return Result<GetInvitesResponse>.Fail("Nenhum invite encontrado.");

        return Result<GetInvitesResponse>.Success(new GetInvitesResponse(invites));

    }
}