using ThePixeler.Models;

namespace ThePixeler.Services.Authorization;

public class EFAuthorizationService(ThePixelerDbContext ctx)
{
    public async Task<RoomRole> GetRole(int roleId)
    {
        var role = await ctx.Roles.FindAsync(roleId);

        return role.RoleName switch
        {
            "Dono" => RoomRole.Dono,
            "Adm" => RoomRole.Adm,
            "Pintor" => RoomRole.Pintor,
            _ => RoomRole.Plateia
        };
    }
}