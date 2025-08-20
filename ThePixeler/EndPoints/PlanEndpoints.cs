namespace ThePixeler.EndPoints;

public static class PlansEndPoints
{
    public static void PlansEndpoints(this WebApplication app)
    {
        app.MapGet("plans", () =>
        {

        });

        app.MapPost("rescue-card/{code}", (string code) => 
        {

        }).RequireAuthorization();
    }
}