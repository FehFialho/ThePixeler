using ThePixeler.Models;
using ThePixeler.Services.ExtractJWTData;
using ThePixeler.Services.Role;

namespace ThePixeler.UseCases.RemoveMember;

public class RemoveMemberUseCase(
    IRoleService roleService,
    ThePixelerDbContext ctx
    )
{
    public async Task<Result<RemoveMemberResponse>> Do(RemoveMemberPayload payload)
    {
        // Target
        var targetID = payload.targetID;
        var targetRU = await ctx.RoomUsers.FindAsync(targetID);
        var target = await ctx.Users.FindAsync(targetID);

        // Pegar Roles
        var targetRoleID = targetRU.RoleID;
        var targetRole = await roleService.GetRole(targetRoleID);

        // Pegar o usuário.
        var roomuser = await ctx.RoomUsers.FindAsync(payload.userID);

        // Pegar Roles
        var roleID = roomuser.RoleID;
        var role = await roleService.GetRole(roleID);

        if ((int)role > 2 && (int)role > (int)targetRole)
            target.Rooms.Remove(targetRU.Room);
        else
            return Result<RemoveMemberResponse>.Fail("Seu cargo precisa ser maior!");


        return Result<RemoveMemberResponse>.Success(null);
    }
}