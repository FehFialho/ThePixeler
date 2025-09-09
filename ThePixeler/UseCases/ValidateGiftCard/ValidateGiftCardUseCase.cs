using ThePixeler.Models;

namespace ThePixeler.UseCases.ValidateGiftCard;

public class ValidateGiftCardUseCase(
    ThePixelerDbContext ctx
)
{
    public async Task<Result<ValidateGiftCardResponse>> Do(ValidateGiftCardPayload payload)
    {
        var user = await ctx.Users.FindAsync(payload.userId);
        var subscription = await ctx.Subscriptions.FindAsync(payload.subscriptionID);
        var giftCard = await ctx.giftCards.FindAsync(payload.code);

        if (giftCard is null)
            return Result<ValidateGiftCardResponse>.Fail("Código Inválido ou já Utilizado!");

        user.Subscription = subscription;
        subscription.Users.Add(user);

        return Result<ValidateGiftCardResponse>.Success(null);
    }
}