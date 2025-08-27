using ThePixeler.Models;
using ThePixeler.Services.IPasswordServices;
using ThePixeler.Services.Profiles;
using ThePixeler.Services.Subscription;

namespace ThePixeler.UseCases.CreateProfile;

public class CreateProfileUseCase
(
    IProfilesService profilesService,
    IPasswordService passwordService,
    ISubscriptionService subscriptionService
)
{
    public async Task<Result<CreateProfileResponse>> Do(CreateProfilePayload payload)
    {
        var user = new User
        {
            Username = payload.UserName,
            Password = passwordService.Hash(payload.Password),
            Email = payload.Email,
            ProfilePicture = payload.ProfilePicture,
            ProfileBio = payload.ProfileBio,
            SubscriptionID = (int)UserSubscription.Gratuito
            //Subscription =  Settar Subscription Padrõa como Default
        };

        await profilesService.Create(user);
        return Result<CreateProfileResponse>.Success(new());
    }

}