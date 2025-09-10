namespace ThePixeler.EndPoints.DTOs;
public record InviteEndpointDTO(
    Guid SenderID, 
    Guid ReceiverID,
    int RoomID,
    bool Response
);