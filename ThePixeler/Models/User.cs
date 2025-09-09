namespace ThePixeler.Models;

public class User
{
    public Guid ID { get; set; }
    public int SubscriptionID { get; set; }

    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string ProfilePicture { get; set; }
    public string ProfileBio { get; set; }
    public DateTime ExpirationDate { get; set; }

    public ICollection<RoomUser> RoomUsers { get; set; }
    public ICollection<Room> Rooms { get; set; } // New
    public ICollection<Invite> InvitesSended { get; set; }
    public ICollection<Invite> InvitesReceived { get; set; }
    public ICollection<Pixel> Pixels { get; set; }
    public Subscription Subscription { get; set; }
}