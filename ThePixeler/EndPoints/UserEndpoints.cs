using Microsoft.AspNetCore.Mvc;
using ThePixeler.UseCases.CreateProfile;
using ThePixeler.UseCases.EditProfileData;
using ThePixeler.UseCases.GetProfile;
using ThePixeler.UseCases.Login;

namespace ThePixeler.EndPoints;
// Auth
public static class AuthEndPoints
{
    public static void ConfigureAuthEndpoints(this WebApplication app)
    {
        app.MapPost("auth", ([FromBody]LoginPayload payload) =>
        {
            // Auth
        });

        app.MapPost("change-info", ([FromBody]EditProfileDataPayload payload) =>
        {

        }).RequireAuthorization();

        app.MapPost("view-profile", ([FromBody]GetProfilePayload payload) =>
        {

        });

        app.MapPost("create-user", ([FromBody]CreateProfilePayload payload) =>
        {
            
        }); 
    }
}