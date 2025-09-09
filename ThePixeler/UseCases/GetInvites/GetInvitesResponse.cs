using ThePixeler.Models;

namespace ThePixeler.UseCases.GetInvites;

public record GetInvitesResponse(
    ICollection<Invite> InvitesReceived 
    
);