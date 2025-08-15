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
public static class ViewRoomsEndPoints
{
    public static void ConfigureViewRoomsEndpoints(this WebApplication app)
    {
        app.MapGet("rooms/{userID}", (int userID) => 
        {

        }); //RequireAuthorization();
    }   
}
// ViewMembers
public static class ViewMembersEndPoints
{
    public static void ConfigureViewMembersEndpoints(this WebApplication app)
    {
        app.MapGet("members/{roomID}", (int roomID) => 
        {

        }); //RequireAuthorization();
    }      
}