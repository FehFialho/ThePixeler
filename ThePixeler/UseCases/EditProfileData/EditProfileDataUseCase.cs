using ThePixeler.Services.ExtractJWTData;

namespace ThePixeler.UseCases.EditProfileData;

public class EditProfileData(
    IExtractJWTData extractJWTData
)
{
    public async Task<Result<EditProfileDataResponse>> Do(EditProfileDataPayload payload)
    {
        // Depois de confirmar o token, pegar o UserID do jwtData.
        // Trocar a informação desejada. Talvez vai ser preciso criar um payload para receber tipo de dado?
        return Result<EditProfileDataResponse>.Success(null);
    }
}
