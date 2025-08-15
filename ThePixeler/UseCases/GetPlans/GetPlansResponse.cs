using ThePixeler.Models;

namespace ThePixeler.UseCases.GetPlans;

public record GetPlansResponse(
    ICollection<Subscription> Subscriptions
);