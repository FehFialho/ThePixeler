namespace ThePixeler.Models;

public class Room
{
    public int RoomID { get; set; }
    public int Height { get; set; }
    public int Width { get; set; }
    public string RoomName { get; set; }

    public ICollection<Invite> Invites { get; set; }
    public ICollection<RoomUser> RoomUsers { get; set; }
    public ICollection<Pixel> Pixels { get; set; }
}