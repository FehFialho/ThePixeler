using Microsoft.EntityFrameworkCore;
using ThePixeler.Models;

namespace ThePixeler.Services.Profiles;

public class EFProfileService(ThePixelerDbContext ctx) : IProfilesService
{
    public async Task<Guid> Create(User profile)
    {
        ctx.Users.Add(profile);
        await ctx.SaveChangesAsync();
        return profile.ID;
    }

    public async Task<User> FindByLogin(string login)
    {
        var profile = await ctx.Users.FirstOrDefaultAsync(
            p => p.Username == login || p.Email == login
        );
        return profile;
    }
}