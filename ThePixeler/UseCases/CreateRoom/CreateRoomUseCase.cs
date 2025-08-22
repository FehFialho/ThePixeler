using ThePixeler.Models;

namespace ThePixeler.UseCases.CreateRoom;

public class CreateRoomUseCase
{
    public async Task<Result<CreateRoomResponse>> Do(CreateRoomPayload payload)
    {
        var room = new Room
        {
            RoomName = payload.RoomName,
            Width = payload.Width,
            Height = payload.Height
        };
        return Result<CreateRoomResponse>.Success(null);
    }
}