namespace ThePixeler.EndPoints;
// CreateRoom
public static class CreateRoomEndPoints
{
    public static void ConfigureCreateRoomEndpoints(this WebApplication app)
    {
        app.MapPost("create-room/{userID}/{height}-{width}", (int userID, int height, int width) => 
        {

        }); //RequireAuthorization();
    }
}
// ViewRooms
public static class RoomsEndPoints
{
    public static void RoomsEndpoints(this WebApplication app)
    {
        app.MapGet("rooms", () =>
        {

        }); //RequireAuthorization();

        app.MapGet("members/{roomID}", (int roomID) => 
        {

        }); //RequireAuthorization();
    }   
}