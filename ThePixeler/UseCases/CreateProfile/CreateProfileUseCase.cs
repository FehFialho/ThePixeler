namespace ThePixeler.UseCases.CreateProfile;

public class CreateProfileUseCase
{
    public async Task<Result<CreateProfileResponse>> Do(CreateProfilePayload payload)
    {
        return Result<CreateProfileResponse>.Success(null);
    }
    
}