using Microsoft.EntityFrameworkCore;

namespace ThePixeler.Models;

public class ThePixelerDbContext(DbContextOptions options) : DbContext(options)
{

    public DbSet<GiftCard> giftCards => Set<GiftCard>();
    public DbSet<Invite> Invites => Set<Invite>();
    public DbSet<Pixel> Pixels => Set<Pixel>();
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<Room> Rooms => Set<Room>();
    public DbSet<RoomUser> RoomUsers => Set<RoomUser>();
    public DbSet<Subscription> Subscriptions => Set<Subscription>();
    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder model)
    {
        //model.Entity<User>()
            //.HasMany(u => u.RoomUsers);
    }
}