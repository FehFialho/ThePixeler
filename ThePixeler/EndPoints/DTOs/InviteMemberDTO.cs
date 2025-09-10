namespace ThePixeler.EndPoints.DTOs;
public record InviteMemberDTO(
    Guid SenderID, 
    Guid ReceiverID,
    int RoomID
);