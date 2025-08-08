namespace ThePixeler.Models;

public class Subscription
{
    public int SubscriptionID { get; set; }
    public string Type { get; set; }

    public ICollection<GiftCard> GiftCards { get; set; }
    public ICollection<User> Users { get; set; }
}