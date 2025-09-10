namespace ThePixeler.EndPoints.DTOs;
//tem tudo que tem no payload mais o que vem do jwt no caso senderid
public record InviteMemberDTO(
    Guid SenderID, 
    Guid ReceiverID,
    int RoomID
);