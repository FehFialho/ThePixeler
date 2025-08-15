using ThePixeler.Models;
namespace ThePixeler.UseCases.GetRoom;

public record GetRoomResponse(
    ICollection<Room> Rooms
);