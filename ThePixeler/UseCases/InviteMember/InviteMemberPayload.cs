namespace ThePixeler.UseCases.InviteMember;

public record InviteMemberPayload(
    Guid SenderID, 
    Guid ReceiverID,
    int RoomID
); 