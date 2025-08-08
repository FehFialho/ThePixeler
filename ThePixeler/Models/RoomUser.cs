namespace ThePixeler.Models;

public class RoomUser
{
    public int RoomUserID { get; set; }
    public int RoomID { get; set; }
    public Guid UserID { get; set; }
    public int RoleID { get; set; }

    public Room Room { get; set; }
    public Role Role { get; set; }
    public User User { get; set; }
}