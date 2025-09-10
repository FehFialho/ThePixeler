namespace ThePixeler.EndPoints.DTOs;
public record RespondInviteDTO(
    Guid userID, // Vem do JWT
    int inviteId,
    bool response,
    int roomID
);