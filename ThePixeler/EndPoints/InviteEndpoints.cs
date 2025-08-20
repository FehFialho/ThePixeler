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
            // Pedir HTTP Request com o Token 
        }).RequireAuthorization();

        app.MapPost("send-invite", ([FromBody]InviteMemberPayload payload) => 
        {
            // Invites a Member
        }).RequireAuthorization();

        app.MapPost("respond-invite", ([FromBody]RespondInvitePayload payload) => 
        {

        }).RequireAuthorization();
    }
}
