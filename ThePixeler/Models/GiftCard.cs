namespace ThePixeler.Models;

public class GiftCard
{
    public int GiftCardID { get; set; }
    public int SubscriptionID { get; set; }
    public string Code { get; set; }
    public int Months { get; set; }
}