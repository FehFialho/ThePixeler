namespace ThePixeler.UseCases.InviteMember;

public record InviteMemberPayload(
    Guid ReceiverID,
    int RoomID
); 