namespace ThePixeler.EndPoints.DTOs;
public record RespondInviteDTO(
    Guid userID,
    int inviteId,
    bool response,
    int roomID
);