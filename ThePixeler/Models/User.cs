namespace ThePixeler.Models;

public class User
{
    public Guid ID { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string ProfilePicture { get; set; }
    public string ProfileBio { get; set; }
    public DateTime ExpirationDate { get; set; }

    public int SubscriptionID { get; set; }
}