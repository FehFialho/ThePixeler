using Microsoft.AspNetCore.Mvc;
using ThePixeler.UseCases.InviteMember;

namespace ThePixeler.EndPoints;
// ViewInvites
public static class ViewInvitesEndPoints
{
    public static void ConfigureInviteEndpoints(this WebApplication app)
    {
        app.MapGet("invites", () =>
        {
            
        }).RequireAuthorization();

        app.MapPost("send-invite", ([FromBody]InviteMemberPayload payload) => 
        {

        }).RequireAuthorization();

        app.MapPost("respond-invite/{inviteId}/{response}", (int inviteId, bool response) => 
        {

        }).RequireAuthorization();
    }
}