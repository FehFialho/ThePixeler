using ThePixeler.Services.ExtractJWTData;
using ThePixeler.Services.JWT;

namespace ThePixeler.UseCases.EditMember;

public class EditMemberUseCase(
    IExtractJWTData extractJWTData
)
{
    public async Task<Result<EditMemberResponse>> Do(EditMemberPayload payload)
    {

        // Pegar o usuário para ver se ele pode mudar o cargo.
        var userID = extractJWTData.GetUserGuid;

        // Procurar o UserID no UserRoom para pegar a role.
        // Se a Role for maior que a do target user, mudar o target.
        // Talvez fazer algo mais básico considerando apenas Membro, ADM, Dono.

        

        return Result<EditMemberResponse>.Success(null);
    }
}