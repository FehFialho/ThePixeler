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
        // RoomUser
        model.Entity<RoomUser>()
            .HasOne(ru => ru.User)
            .WithMany(u => u.RoomUsers)
            .HasForeignKey(ru => ru.UserID)
            .OnDelete(DeleteBehavior.NoAction);

        model.Entity<RoomUser>()
            .HasOne(ru => ru.Role)
            .WithMany(r => r.RoomUsers)
            .HasForeignKey(ru => ru.RoleID)
            .OnDelete(DeleteBehavior.NoAction);

        model.Entity<RoomUser>()
            .HasOne(ru => ru.Room)
            .WithMany(r => r.RoomUsers)
            .HasForeignKey(ru => ru.RoomID)
            .OnDelete(DeleteBehavior.NoAction);

        // Invite
        model.Entity<Invite>()
            .HasOne(i => i.Sender)
            .WithMany(s => s.InvitesSended)
            .HasForeignKey(i => i.SenderID)
            .OnDelete(DeleteBehavior.NoAction);

        model.Entity<Invite>()
            .HasOne(i => i.Receiver)
            .WithMany(s => s.InvitesReceived)
            .HasForeignKey(i => i.ReceiverID)
            .OnDelete(DeleteBehavior.NoAction);

        model.Entity<Invite>()
            .HasOne(i => i.Room)
            .WithMany(r => r.Invites)
            .HasForeignKey(i => i.RoomID)
            .OnDelete(DeleteBehavior.NoAction);

        //Pixel
        model.Entity<Pixel>()
            .HasOne(p => p.Room)
            .WithMany(r => r.Pixels)
            .HasForeignKey(p => p.RoomID)
            .OnDelete(DeleteBehavior.NoAction);

        model.Entity<Pixel>()
            .HasOne(p => p.User)
            .WithMany(u => u.Pixels)
            .HasForeignKey(p => p.UserID)
            .OnDelete(DeleteBehavior.NoAction);

        //User
        model.Entity<User>()
            .HasOne(u => u.Subscription)
            .WithMany(s => s.Users)
            .HasForeignKey(u => u.SubscriptionID)
            .OnDelete(DeleteBehavior.NoAction);

        //Gift Card
        model.Entity<GiftCard>()
            .HasOne(g => g.Subscription)
            .WithMany(s => s.GiftCards)
            .HasForeignKey(g => g.SubscriptionID)
            .OnDelete(DeleteBehavior.NoAction);
    }
}