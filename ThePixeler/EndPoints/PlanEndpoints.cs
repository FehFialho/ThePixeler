namespace ThePixeler.EndPoints;
// ViewPlans
public static class ViewPlansEndPoints
{
    public static void ConfigureViewPlansEndpoints(this WebApplication app)
    {
        app.MapGet("plans", () =>
        {

        });
    }
}

// RescueCard
public static class RescueCardEndPoints
{
    public static void ConfigureViewPlansEndpoints(this WebApplication app)
    {
        app.MapPost("rescue-card/{code}", (int code) => 
        {

        }); //RequireAuthorization();
    }
}