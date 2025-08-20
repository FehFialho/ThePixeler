namespace ThePixeler.EndPoints;
// EditMember
public static class MemberEndPoints
{
    public static void MemberEndpoints(this WebApplication app)
    {
        app.MapPut("edit-member/{userGuid}", (Guid userGuid) =>
        {

        }).RequireAuthorization();
    
        app.MapDelete("remove-member/{userGuid}", (Guid userGuid) => 
        {

        }).RequireAuthorization();
    
    }
}
