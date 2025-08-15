using ThePixeler.Models;

namespace ThePixeler.UseCases.GetInvites;

public record GetInvitesResponse(
    User InvitesReceived
);