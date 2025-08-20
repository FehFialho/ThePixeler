namespace ThePixeler.EndPoints;
// Auth
public static class AuthEndPoints
{
    public static void ConfigureAuthEndpoints(this WebApplication app)
    {
        app.MapPost("auth/{username}/{password}", (string username, string password) =>
        {
            // Mudar Depois
        });

        app.MapPost("change-info/{userID}/{info}", (int userID, string info) =>
        {

        }); //RequireAuthorization();

        app.MapPost("view-profile/{userID}", (int userID) =>
        {

        });

        app.MapPost("create-user/{username}/{password}", (string username, string password) =>
        {
            //MUDAR DEPOIS
        }); 
    }
}