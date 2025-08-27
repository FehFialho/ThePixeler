using ThePixeler.Models;

namespace ThePixeler.UseCases.GetProfile;

public class GetProfileUseCase (ThePixelerDbContext ctx)
{
    public async Task<Result<GetProfileResponse>> Do(GetProfilePayload payload)
    {
        // Inserir em uma variável o objeto do usuário encontrado a partir da comparação do Username recebido no Payload.
        var user = await ctx.Users.FindAsync(payload.Username);
        
        if (user == null)
            return Result<GetProfileResponse>.Fail("Usuário não encontrado");

        return Result<GetProfileResponse>.Success(new(user));
    }
}