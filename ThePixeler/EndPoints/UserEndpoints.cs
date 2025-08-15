namespace ThePixeler.EndPoints;
// Auth
public static class AuthEndPoints
{
    public static void ConfigureAuthEndpoints(this WebApplication app)
    {
        app.MapPost("auth/{username}/{password}", (string username, string password) =>
        {
            // Mudar Depois
        }); //RequireAuthorization();
    }
}

// EditProfileData
public static class EditProfileDataEndPoints
{
    public static void ConfigureEditProfileDataEndpoints(this WebApplication app)
    {
        app.MapPost("change-info/{userID}/{info}", (int userID, string info) =>
        {

        }); //RequireAuthorization();
    }
}

// ViewProfile
public static class ViewProfileEndPoints
{
    public static void ConfigureViewProfileEndpoints(this WebApplication app)
    {
        app.MapPost("view-profile/{userID}", (int userID) =>
        {

        });
    }
}

// CreateUser
public static class CreateUserEndPoints
{
    public static void ConfigureCreateUserEndpoints(this WebApplication app)
    {
        app.MapPost("create-user/{username}/{password}", (string username, string password) =>
        {
            //MUDAR DEPOIS
        }); 
    }
}