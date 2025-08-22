using ThePixeler.Models;
using ThePixeler.Services.ExtractJWTData;

namespace ThePixeler.UseCases.CreateRoom;

public class CreateRoomUseCase(
    IExtractJWTData extractJWTData
)
{
    public async Task<Result<CreateRoomResponse>> Do(CreateRoomPayload payload)
    {

        var UserSubscription = extractJWTData.GetUserSubscriptionID(); // Pegar o ID ou a própria Sub?

        // Fazer IF para checar subscription e se o tamanho da sala é compatível.

        var room = new Room
        {
            RoomName = payload.RoomName,
            Width = payload.Width,
            Height = payload.Height
        };

        // Criação da Sala

        return Result<CreateRoomResponse>.Success(new());
    }
}