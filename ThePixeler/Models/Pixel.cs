namespace ThePixeler.Models;

public class Pixel
{
    public int PixelID { get; set; }
    public Guid UserID { get; set; }
    public int RoomID { get; set; }

    public int xPosition { get; set; }
    public int yPosition { get; set; }
    public int R { get; set; } 
    public int G { get; set; } 
    public int B { get; set; } 

    public Room Room { get; set; }
    public User User { get; set; }
}