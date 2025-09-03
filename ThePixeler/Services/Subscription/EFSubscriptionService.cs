using ThePixeler.Models;

namespace ThePixeler.Services.Subscription;

public class EFSubscriptionService(ThePixelerDbContext ctx)
{
    public async Task<UserSubscription> GetSubscription(int subscriptionID)
    {
        var sub = await ctx.Subscriptions.FindAsync(subscriptionID);

        return sub.Type switch
        {
            "Gold" => UserSubscription.Gold,
            "Platinum" => UserSubscription.PLatinum,
            _ => UserSubscription.Gratuito
        };
    }
}