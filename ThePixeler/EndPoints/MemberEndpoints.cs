namespace ThePixeler.EndPoints;
// EditMember
public static class EditMemberEndPoints
{
    public static void ConfigureEditMemberEndpoints(this WebApplication app)
    {
        app.MapPost("edit-member/{userGuid}", (Guid userGuid) => 
        {
        }); //RequireAuthorization();
    }
}
// RemoveMember
public static class RemoveMemberEndPoints
{
    public static void ConfigureRemoveMemberEndpoints(this WebApplication app)
    {
        app.MapPost("remove-member/{userGuid}", (Guid userGuid) => 
        {

        }); //RequireAuthorization();
    }
}