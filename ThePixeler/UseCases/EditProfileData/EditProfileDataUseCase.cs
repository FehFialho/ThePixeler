namespace ThePixeler.UseCases.EditProfileData;

public class EditProfileData
{
    public async Task<Result<EditProfileDataResponse>> Do(EditProfileDataPayload payload)
    {
        return Result<EditProfileDataResponse>.Success(null);
    }
}
