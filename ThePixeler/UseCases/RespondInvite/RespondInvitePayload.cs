namespace ThePixeler.UseCases.RespondInvite;

public record RespondInvitePayload(
    int inviteId,
    bool response,
    int roomID
);