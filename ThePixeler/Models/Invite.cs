namespace ThePixeler.Models;

public class Invite
{
    public int InviteID { get; set; }
    public int RoomID { get; set; }
    public Guid SenderID { get; set; }
    public Guid ReceiverID { get; set; }

    public Room Room { get; set; }
    public User User { get; set; }
}