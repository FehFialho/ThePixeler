using ThePixeler.Models;
using ThePixeler.Services.ExtractJWTData;

namespace ThePixeler.UseCases.EditProfileData;

public class EditProfileData(
    IExtractJWTData extractJWTData,
    ThePixelerDbContext ctx
)
{
    public async Task<Result<EditProfileDataResponse>> Do(EditProfileDataPayload payload)
    {

        var userID = await extractJWTData.GetUserGuid(payload.HttpContext);
        var user = await ctx.Users.FindAsync(userID);
        // Depois de confirmar o token, pegar o UserID do jwtData.

        
        // Trocar a informação desejada. Talvez vai ser preciso criar um payload para receber tipo de dado?
        return Result<EditProfileDataResponse>.Success(null);
    }
}
