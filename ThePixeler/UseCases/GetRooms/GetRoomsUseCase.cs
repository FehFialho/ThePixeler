namespace ThePixeler.UseCases.GetRoom;

public class GetRoomUseCase
{
    public async Task<Result<GetRoomResponse>> Do(GetRoomPayload payload)
    {
        return Result<GetRoomResponse>.Success(null);
    }
}