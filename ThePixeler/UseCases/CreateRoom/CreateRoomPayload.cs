namespace ThePixeler.UseCases.CreateRoom;

public record CreateRoomPayload
{
    public string RoomName { get; set; }
    public int Width { get; set; }
    public int Heigth { get; set; }

}