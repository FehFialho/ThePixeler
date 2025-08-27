using ThePixeler.Models;
using ThePixeler.Services.ExtractJWTData;
using ThePixeler.Services.Subscription;

namespace ThePixeler.UseCases.CreateRoom;

public class CreateRoomUseCase(
    IExtractJWTData extractJWTData,
    ISubscriptionService subscriptionService,
    ThePixelerDbContext ctx
)
{
    public async Task<Result<CreateRoomResponse>> Do(CreateRoomPayload payload)
    {
        var userID = await extractJWTData.GetUserGuid(payload.HttpContext);
        var user = await ctx.Users.FindAsync(userID);

        var maxSize = 64;
        var subscriptionID = await extractJWTData.GetUserSubscriptionID(payload.HttpContext);
        var subscription = await subscriptionService.GetSubscription(subscriptionID);

        // Verificação de Tamanho Máximo.
        if (subscription == UserSubscription.Gold)
            maxSize = 128;
        else if (subscription == UserSubscription.PLatinum)
            maxSize = 256;

        if (payload.Width > maxSize && payload.Height > maxSize)
            return Result<CreateRoomResponse>.Fail("Tamanho máximo excedido!");

        var room = new Room
        {
            RoomName = payload.RoomName,
            Width = payload.Width,
            Height = payload.Height
        };

        user.Rooms.Add(room);
        // Adicionar Sala em Salas do User
        ctx.Rooms.Add(room);
        await ctx.SaveChangesAsync();

        return Result<CreateRoomResponse>.Success(new());
    }
}