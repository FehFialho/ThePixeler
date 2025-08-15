namespace ThePixeler.EndPoints;
// ViewInvites
public static class ViewInvitesEndPoints
{
    public static void ConfigureViewInviteEndpoints(this WebApplication app)
    {
        app.MapGet("invites/{userGuid}", (Guid userGuid) => 
        {

        }); //RequireAuthorization();
    }
}
// SendInvite
public static class SendInviteEndPoints
{
    public static void ConfigureSendInviteEndpoints(this WebApplication app)
    {
        app.MapPost("send-invite/{userGuid}", (Guid userGuid) => 
        {

        }); //RequireAuthorization();
    }
}
// RespondInvite
public static class RespondInviteEndPoints
{
    public static void ConfigureRespondInviteEndpoints(this WebApplication app)
    {
        app.MapPost("respond-invite/{inviteId}/{response}", (int inviteId, bool response) => 
        {

        }); //RequireAuthorization();
    }    
}