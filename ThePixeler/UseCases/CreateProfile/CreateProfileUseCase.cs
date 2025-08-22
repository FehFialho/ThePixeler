using System.Runtime;
using ThePixeler.Models;
using ThePixeler.Services.Profiles;
using ThePixeler.UseCases.CreateProfile;

namespace ThePixeler.UseCases.CreateProfile;

public class CreateProfileUseCase
(
    IProfilesService profilesService
)
{
    public async Task<Result<CreateProfileResponse>> Do(CreateProfilePayload payload)
    {
        var user = new User
        {
            Username = payload.UserName,
            Password = payload.Password,
            Email = payload.Email,
            ProfilePicture = payload.ProfilePicture,
            ProfileBio = payload.ProfileBio,
            //Subscription =  Settar Subscription Padrõa como Default
        };
        return Result<CreateProfileResponse>.Success(null);
    }

}