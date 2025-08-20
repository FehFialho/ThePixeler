namespace ThePixeler.EndPoints;
// CreateRoom
public static class CreateRoomEndPoints
{
    public static void ConfigureRoomEndpoints(this WebApplication app)
    {
        app.MapPost("create-room", ([FromBody]CreateRoomPayload) => 
        {

        }).RequireAuthorization();

        // ViewRooms
        app.MapGet("rooms", () =>
        {

        }).RequireAuthorization();

        app.MapGet("members", ([FromBody]GetMembersPayload payload) => 
        {
            // Get Room Members
        }).RequireAuthorization();
    }
}