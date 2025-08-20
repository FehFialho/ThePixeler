namespace ThePixeler.UseCases.CreateRoom;

public record CreateRoomPayload(
    string RoomName,
    int Width ,
    int Heigth
);
