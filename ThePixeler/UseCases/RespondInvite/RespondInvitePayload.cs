namespace ThePixeler.UseCases.RespondInvite;

public record RespondInvitePayload(
    int inviteId,
    bool Response
);