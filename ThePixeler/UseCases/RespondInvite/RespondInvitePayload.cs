namespace ThePixeler.UseCases.RespondInvite;

public record RespondInvitePayload(
    Guid userID,
    int inviteId,
    bool Response
);