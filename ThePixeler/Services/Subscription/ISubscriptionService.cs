using ThePixeler.Models;

namespace ThePixeler.Services.Subscription;

public enum UserSubscription
{
    Gratuito = 1,
    Gold = 2,
    PLatinum = 3
}

public interface ISubscriptionService
{
    Task<UserSubscription> GetSubscription(int userId);
}