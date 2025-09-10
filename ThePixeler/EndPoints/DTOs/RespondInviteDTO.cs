public record RespondInviteDTO(
    int InviteID,
    int RoomID,
    Guid UserID,
    bool Response
);
